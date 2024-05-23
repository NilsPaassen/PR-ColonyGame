using UnityEngine;
using UnityEngine.InputSystem;
using static Actions;

public class BuildingPlacing : MonoBehaviour
{
    private Actions actions;
    private InputAction buildModeAction;
    private BuildModeActions buildModeActions;
    private InputAction rotateAction;
    private InputAction placeAction;

    private bool inBuildMode = false;

    //Cube placeholder until real building possible
    public GameObject selectedBuilding;

    //for building preview
    private GameObject previousHit;
    private GameObject previousInstance;
    private Color PREVIEW_GREEN = new Color(0.1f, 1f, 0.1f);

    //for rotation
    private Quaternion buildingRotation;

    // Start is called before the first frame update
    void Start()
    {
        actions = new();
        PlayerActions playerActions = actions.Player;
        playerActions.Enable();
        buildModeAction = playerActions.BuildMode;
        buildModeActions = actions.BuildMode;
        rotateAction = buildModeActions.Rotate;
        placeAction = buildModeActions.Place;
    }

    // Update is called once per frame
    void Update()
    {
        //When B is pressed go to build mode
        if (buildModeAction.WasPressedThisFrame())
        {
            if (inBuildMode)
            {
                buildModeActions.Disable();
                inBuildMode = false;
            }
            else
            {
                buildingRotation = Quaternion.identity;
                inBuildMode = true;
                buildModeActions.Enable();
            }
        }

        if (inBuildMode)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //layer 3 == BuildableOn
            if (
                Physics.Raycast(ray, out hit, 1000.0f)
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
                    hit.transform.position + selectedBuilding.transform.position,
                    buildingRotation
                );
            }
        }
        else if (previousInstance != null)
        {
            Destroy(previousInstance, 0);
        }

        //Rotate by 90°
        if (rotateAction.WasPressedThisFrame())
        {
            previousInstance.transform.Rotate(transform.up, 90f);
            buildingRotation = previousInstance.transform.rotation;
        }

        // 0 = left
        //Checks if preview is currently intersecting by checking if the color has been changed to red by the BuildingSpaceAvailable Script
        if (
            placeAction.WasPressedThisFrame()
            && previousInstance.GetComponent<MeshRenderer>().material.GetColor("_previewColor")
                != new Color(1f, 0.1f, 0.1f)
        )
        {
            //Sets the Material Parameters in all Children of the placed Building
            foreach (
                MeshRenderer meshRenderer in previousInstance.GetComponentsInChildren<MeshRenderer>()
            )
            {
                foreach (Material mat in meshRenderer.materials)
                {
                    if (mat.HasColor("_previewColor"))
                    {
                        mat.SetColor("_previewColor", Color.black);
                        //SetInt is apparently how you change bools(0=false;1=true)
                        mat.SetInt("_isPreview", 0);
                        mat.SetFloat("_alpha", 1);
                    }
                }
            }

            //sets Is Trigger to true so that the building can now interact with the Building preview
            previousInstance.GetComponent<Collider>().isTrigger = true;

            //tries to activate the building specific scripts
            if (previousInstance.TryGetComponent<ConveyorBelt>(out ConveyorBelt conveyorBelt))
            {
                conveyorBelt.OnBuild();
            }

            //makes previousInstance permament by removing the refrenced GameObject from the variable, thus it no longer gets deleted
            previousInstance = null;
        }
    }
}
