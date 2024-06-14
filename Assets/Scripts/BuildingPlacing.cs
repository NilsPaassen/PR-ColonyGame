using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static Actions;

public class BuildingPlacing : MonoBehaviour
{
    private InputAction buildModeAction;
    private BuildModeActions buildModeActions;
    private InputAction cursorAction;
    private InputAction rotateAction;
    private InputAction placeAction;

    private bool inBuildMode = false;
    private bool buildModePaused = false;

    //Cube placeholder until real building possible
    public GameObject selectedBuilding;

    //for building preview
    private GameObject previousHit;
    private GameObject previousInstance;

    //for rotation
    private Quaternion buildingRotation;

    //for checking if ground type
    private String groundTag;

    // Start is called before the first frame update
    void Start()
    {
        Actions actions = new();
        PlayerActions playerActions = actions.Player;
        playerActions.Enable();
        buildModeAction = playerActions.BuildMode;
        buildModeActions = actions.BuildMode;
        cursorAction = buildModeActions.Cursor;
        rotateAction = buildModeActions.Rotate;
        placeAction = buildModeActions.Place;
    }

    // Update is called once per frame
    void Update()
    {
        //When B is pressed go to build mode
        if (buildModeAction.WasPressedThisFrame())
        {
            changeBuildMode();
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
            placeAction.WasPressedThisFrame()
            && previousInstance != null
            && previousInstance.GetComponent<MeshRenderer>().material.GetColor("_previewColor")
                != new Color(1f, 0.1f, 0.1f)
        )
        {
            PlaceBuilding();
        }
    }

    public void enableBuildMode()
    {
        buildingRotation = selectedBuilding.transform.rotation;
        inBuildMode = true;
    }

    public void pauseBuildMode()
    {
        buildModeActions.Disable();
        buildModePaused = true;
    }

    public void resumeBuildMode()
    {
        buildModePaused = false;
        if (inBuildMode)
        {
            buildModeActions.Enable();
        }
    }

    private void changeBuildMode()
    {
        if (inBuildMode)
        {
            buildModeActions.Disable();
            inBuildMode = false;
        }
        else
        {
            enableBuildMode();
            if (!buildModePaused)
            {
                buildModeActions.Enable();
            }
        }
    }

    private void PlacePreview()
    {
        Ray ray = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());
        //layer 3 == BuildableOn
        if (
            Physics.Raycast(ray, out RaycastHit hit, 1000.0f,~LayerMask.GetMask("Preview"))
            && hit.collider.gameObject.layer == LayerMask.NameToLayer("BuildableOn")
            && hit.collider.gameObject != previousHit
        )
        {
            //if a preview Instance exists it gets destroyed
            if (previousInstance != null)
            {
                Destroy(previousInstance, 0);
            }
            
            previousInstance = Instantiate(
                selectedBuilding,
                 new Vector3(Mathf.RoundToInt(hit.point.x),Mathf.RoundToInt(hit.point.y),Mathf.RoundToInt(hit.point.z))+ selectedBuilding.transform.position,
                buildingRotation
            );
            groundTag = hit.collider.gameObject.tag;
            //colors building red if they cannot be build
            //TODO: Add resource check
            if (!BuildingIsPlacable())
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
        foreach (Collider collider in previousInstance.GetComponents<Collider>())
        {
            collider.isTrigger = true;
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
}
