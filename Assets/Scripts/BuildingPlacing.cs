using UnityEngine;

public class BuildingPlacing : MonoBehaviour
{

    private bool inBuildMode = false;
    //Cube placeholder until real building possible
    public GameObject selectedBuilding;

    //for building preview
    private GameObject previousHit;
    private GameObject previousInstance;
    private Color PREVIEW_GREEN = new Color(20, 255, 20);
    private Color PREVIEW_RED = new Color(20, 255, 20);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //When B is pressed go to build mode
        if (Input.GetKeyDown(KeyCode.B))
        {
            inBuildMode = !inBuildMode;
        }

        if (inBuildMode)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.collider.gameObject.layer == 3 && hit.collider.gameObject != previousHit)
            {
                //if a preview Instance exists it gets destroyed
                if (previousInstance != null)
                {
                    Destroy(previousInstance, 0);
                }
                previousInstance = Instantiate(selectedBuilding, hit.transform.position, UnityEngine.Quaternion.identity);

                foreach (Material mat in previousInstance.GetComponent<MeshRenderer>().materials)
                {
                    Debug.Log(mat.GetFloat("_alpha"));
                }
            }
        }
        else if (previousInstance != null)
        {
            Destroy(previousInstance, 0);
        }
        // 0 = left
        if (Input.GetMouseButtonDown(0) && inBuildMode && previousInstance != null)
        {

            //needs to set material to actual material
            foreach (Material mat in previousInstance.GetComponent<MeshRenderer>().materials)
            {
                mat.SetColor("_previewColor", Color.black);
                //SetInt is apparently how you change bools(0=false;1=true)
                mat.SetInt("_isPreview", 0);
                mat.SetFloat("_alpha", 1);
            }
            //makes previousInstance permament by removing the refrenced GameObject from the variable, thus it no longer gets deleted
            previousInstance = null;
        }
    }
}
