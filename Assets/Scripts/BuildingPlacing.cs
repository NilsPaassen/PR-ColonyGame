using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static Actions;

public class BuildingPlacing : MonoBehaviour
{
    private InputAction buildModeAction;
    private InputAction cursorAction;
    private InputAction rotateAction;
    private InputAction interactAction;
    private InputAction destroyAction;

    private bool inBuildMode = false;
    private bool buildModePaused = false;
    private bool inDestroyMode = false;

    //Cube placeholder until real building possible
    public GameObject selectedBuilding;

    //for building preview
    private Vector3 previousHitPos;
    private GameObject previousInstance;

    //for destroy mode
    private GameObject previousTarget;

    //for rotation
    private Quaternion buildingRotation;

    //for checking if ground type
    private String groundTag;

    Ray ray;

    private BuildingManager buildingManager;
    private BuildingResourceHandler buildingResourceHandler;

    // Start is called before the first frame update
    void Start()
    {
        buildingManager = GameObject
            .FindGameObjectWithTag("WorldController")
            .GetComponent<BuildingManager>();
        buildingResourceHandler = GameObject
            .FindGameObjectWithTag("WorldController")
            .GetComponent<BuildingResourceHandler>();
        Actions actions = new();
        PlayerActions playerActions = actions.Player;
        playerActions.Enable();
        buildModeAction = playerActions.BuildMode;
        cursorAction = playerActions.Cursor;
        rotateAction = playerActions.RotateBuilding;
        interactAction = playerActions.Interact;
        destroyAction = playerActions.DestroyBuilding;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());
        if (destroyAction.WasPressedThisFrame())
        {
            inDestroyMode = !inDestroyMode;
            if (!inDestroyMode && previousTarget != null)
            {
                ChangeObjectOutline(Color.black, 0.01f, previousTarget);
            }
            DisableBuildMode();
        }

        if (inDestroyMode)
        {
            GameObject target = null;
            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, ~LayerMask.GetMask("Preview")))
            {
                target = 6 == hit.collider.gameObject.layer ? hit.collider.gameObject : null;
                if (target != null)
                {
                    while (target.transform.parent != null)
                    {
                        target = target.transform.parent.gameObject;
                    }
                }
            }

            if (target != null && target != previousTarget)
            {
                //set outline color to red
                ChangeObjectOutline(Color.red, 0.075f, target);
            }
            if (previousTarget != null && target != previousTarget)
            {
                //reset the outline of the previous target
                ChangeObjectOutline(Color.black, 0.01f, previousTarget);
            }
            if (interactAction.WasPressedThisFrame() && target != null)
            {
                if (target.TryGetComponent<Building>(out Building b))
                {
                    b.OnDestroyCustom();
                }
                DestroyBuilding(target);
            }
            previousTarget = target;
        }

        //When B is pressed go to build mode
        if (buildModeAction.WasPressedThisFrame())
        {
            ChangeBuildMode();
        }

        if (inBuildMode && !buildModePaused)
        {
            PlacePreview();
        }
        else if (previousInstance != null)
        {
            Destroy(previousInstance, 0);
        }

        //Rotate by 90°
        if (rotateAction.WasPressedThisFrame() && previousInstance != null)
        {
            previousInstance.transform.Rotate(new Vector3(0, 1, 0), 90f, Space.World);
            buildingRotation = previousInstance.transform.rotation;
        }

        // 0 = left
        //Checks if preview is currently intersecting by checking if the color has been changed to red by the BuildingSpaceAvailable Script
        if (
            interactAction.WasPressedThisFrame()
            && previousInstance != null
            && previousInstance.GetComponent<MeshRenderer>().material.GetColor("_previewColor")
                != new Color(1f, 0.1f, 0.1f)
        )
        {
            PlaceBuilding();
        }
    }

    private void ChangeObjectOutline(Color pColor, float pThickness, GameObject pTarget)
    {
        //set outline color to red
        foreach (Transform t in pTarget.GetComponentsInChildren<Transform>())
        {
            Material[] materials = t.gameObject.GetComponent<MeshRenderer>().materials;
            if (materials[materials.Length - 1].HasColor("_OutlineColor"))
            {
                materials[materials.Length - 1].SetColor("_OutlineColor", pColor);
                materials[materials.Length - 1].SetFloat("_OutlineThickness", pThickness);
            }
        }
    }

    public Mode GetMode()
    {
        if (inBuildMode)
        {
            return Mode.Build;
        }
        if (inDestroyMode)
        {
            return Mode.Destroy;
        }
        return Mode.Select;
    }

    public void EnableBuildMode()
    {
        buildingRotation = selectedBuilding.transform.rotation;
        inBuildMode = true;
        inDestroyMode = false;
        if (previousTarget != null)
            ChangeObjectOutline(Color.black, 0.01f, previousTarget);
    }

    public void DisableBuildMode()
    {
        inBuildMode = false;
    }

    public void PauseBuildMode()
    {
        buildModePaused = true;
    }

    public void ResumeBuildMode()
    {
        buildModePaused = false;
    }

    private void ChangeBuildMode()
    {
        if (inBuildMode)
        {
            DisableBuildMode();
        }
        else
        {
            EnableBuildMode();
        }
    }

    private void PlacePreview()
    {
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue, 10f);
        //layer 3 == BuildableOn
        if (
            Physics.Raycast(
                ray,
                out RaycastHit hit,
                1000.0f,
                ~LayerMask.GetMask("Preview", "Building")
            )
            //unter keinen umständen hinterfragen| guckt ob layer in der mask ist
            && LayerMask.GetMask("BuildableOn", "OrePlace")
                == (
                    (1 << hit.collider.gameObject.layer)
                    | LayerMask.GetMask("BuildableOn", "OrePlace")
                )
            && previousHitPos
                != new Vector3(
                    Mathf.RoundToInt(hit.point.x),
                    Mathf.RoundToInt(hit.point.y),
                    Mathf.RoundToInt(hit.point.z)
                )
        )
        {
            groundTag = hit.collider.gameObject.tag;
            previousHitPos = new Vector3(
                Mathf.RoundToInt(hit.point.x),
                Mathf.RoundToInt(hit.point.y),
                Mathf.RoundToInt(hit.point.z)
            );
            //if a preview Instance exists it gets destroyed
            if (previousInstance != null)
            {
                Destroy(previousInstance, 0);
            }
            previousInstance = Instantiate(
                selectedBuilding,
                new Vector3(
                    Mathf.RoundToInt(hit.point.x),
                    Mathf.RoundToInt(hit.point.y),
                    Mathf.RoundToInt(hit.point.z)
                ) + selectedBuilding.transform.position,
                buildingRotation
            );
            groundTag = hit.collider.gameObject.tag;
            //colors building red if they cannot be build
            //TODO: Add resource check
            if (!BuildingIsPlacable() || !EnoughResourcesForBuilding())
            {
                foreach (
                    MeshRenderer meshRenderer in previousInstance.GetComponentsInChildren<MeshRenderer>()
                )
                {
                    foreach (Material mat in meshRenderer.materials)
                    {
                        if (mat.HasColor("_previewColor"))
                        {
                            mat.SetColor("_previewColor", new Color(1f, 0.1f, 0.1f));
                        }
                    }
                }
            }
        }
    }

    private void DestroyBuilding(GameObject target)
    {
        //Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 10f);


        if (target)
        {
            foreach (Transform t in target.GetComponentInChildren<Transform>())
            {
                if (t.gameObject)
                    Destroy(t.gameObject);
            }

            Destroy(target);
        }
    }

    private void PlaceBuilding()
    {
        //Sets the Material Parameters in all Children of the placed Building
        foreach (
            MeshRenderer meshRenderer in previousInstance.GetComponentsInChildren<MeshRenderer>()
        )
        {
            foreach (Material mat in meshRenderer.materials)
            {
                //checks if the material is used in the preview
                if (mat.HasColor("_previewColor"))
                {
                    mat.SetColor("_previewColor", Color.black);
                    //SetInt is apparently how you change bools(0=false;1=true)
                    mat.SetInt("_isPreview", 0);

                    //makes mat opaque
                    mat.SetInt("_SurfaceType", 0);
                    mat.SetInt("_RenderQueueType", 1);
                    mat.SetFloat("_AlphaDstBlend", 0f);
                    mat.SetFloat("_DstBlend", 0f);
                    mat.SetFloat("_ZTestDepthEqualForOpaque", 3f);
                    mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;

                    mat.SetFloat("_alpha", 1);
                }
            }
        }

        //sets Is Trigger to true so that the building can now interact with the Building preview
        foreach (Collider collider in previousInstance.GetComponentsInChildren<Collider>())
        {
            collider.isTrigger = true;
        }

        //subtracts amount needed for building from storage
        JSONStructures.Resource[] required = buildingManager
            .GetFromAllBuildings(selectedBuilding.name)
            .cost;
        foreach (JSONStructures.Resource resource in required)
        {
            buildingResourceHandler.storage[resource.resourceName] -= resource.amount;
        }

        //tries to activate the building specific scripts
        Building building = previousInstance.GetComponent<Building>();
        if (previousInstance.CompareTag("Mine"))
        {
            building.OnBuild(groundTag);
        }
        else if (building)
        {
            building.OnBuild();
        }
        previousInstance.layer = LayerMask.NameToLayer("Building");
        foreach (Transform g in previousInstance.GetComponentsInChildren<Transform>())
        {
            g.GameObject().layer = LayerMask.NameToLayer("Building");
        }
        //makes previousInstance permament by removing the refrenced GameObject from the variable, thus it no longer gets deleted
        previousInstance = null;
    }

    private bool BuildingIsPlacable()
    {
        //cannot build on Water
        if (groundTag == "Water")
        {
            return false;
        }
        //cannot build a mine on a ground plane that is not tagged with one of the minable things
        if (
            previousInstance.CompareTag("Mine")
            & !(groundTag == "IronOre" || groundTag == "Cole" || groundTag == "CopperOre")
        )
        {
            return false;
        }
        return true;
    }

    private bool EnoughResourcesForBuilding()
    {
        JSONStructures.Resource[] required = buildingManager
            .GetFromAllBuildings(selectedBuilding.name)
            .cost;
        foreach (JSONStructures.Resource resource in required)
        {
            if (
                buildingResourceHandler.storage.TryGetValue(resource.resourceName, out int value)
                && value < resource.amount
            )
            {
                return false;
            }
        }
        return true;
    }
}
