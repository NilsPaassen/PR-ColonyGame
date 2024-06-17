using Unity.VisualScripting;
using UnityEngine;

public class ConveyorBelt : Building
{
    public GameObject nextConveyorBelt;
    public GameObject[] carriedObjects = new GameObject[3];
    private float speedModifier = 1f;

    //0 == middle; 1 == end; 2 == beginning;
    public int position = 0;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public GameObject CheckForFrontConveyor()
    {
        //the end object should never change what their next object is
        if (position == 1)
        {
            return nextConveyorBelt;
        }
        RaycastHit hit;
        Ray ray = new Ray(
            transform.position + new Vector3(0, 0.05f, 0),
            Quaternion.Euler(transform.rotation.eulerAngles) * new Vector3(-1, 0, 0)
        );
        Physics.Raycast(ray, out hit, 1f);
        if (
            hit.collider
            && hit.collider.gameObject.CompareTag("ConveyorBelt")
            && hit.collider.gameObject.GetComponent<MeshRenderer>().material.GetInt("_isPreview")
                == 0
        )
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    public override void OnBuild()
    {
        nextConveyorBelt = CheckForFrontConveyor();
        Invoke("TransferCarriedObjecs", 1f * speedModifier);
    }

    void TransferCarriedObjecs()
    {
        if (nextConveyorBelt == null)
        {
            nextConveyorBelt = CheckForFrontConveyor();
        }
        else
        {
            //gives to the next object
            ConveyorBelt next = nextConveyorBelt.GetComponent<ConveyorBelt>();
            if (next.carriedObjects[2] == null && carriedObjects[0] != null)
            {
                next.carriedObjects[2] = carriedObjects[0];
                carriedObjects[0].transform.position =
                    nextConveyorBelt.transform.position
                    - Quaternion.Euler(nextConveyorBelt.transform.rotation.eulerAngles)
                        * new Vector3(-0.35f, 0, 0)
                    + new Vector3(0, .2f, 0);
                carriedObjects[0] = null;
            }
        }
        //transports in the conveyorbelt
        for (int i = 0; i < carriedObjects.Length - 1; i++)
        {
            if (carriedObjects[i] == null && carriedObjects[i + 1] != null)
            {
                carriedObjects[i] = carriedObjects[i + 1];
                carriedObjects[i + 1].transform.position =
                    transform.position
                    + Quaternion.Euler(transform.rotation.eulerAngles)
                        * new Vector3(-0.35f, 0, 0)
                        * (1 - i)
                    + new Vector3(0, .2f, 0);
                carriedObjects[i + 1] = null;
            }
        }
        Invoke("TransferCarriedObjecs", 1f * speedModifier);
    }
}
