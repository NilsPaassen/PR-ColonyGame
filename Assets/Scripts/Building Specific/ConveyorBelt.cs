using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ConveyorBelt : Building
{
    public GameObject nextConveyorBelt;
    public GameObject[] carriedObjects = new GameObject[3];
    private float speedModifier = 1f;

    //0 == middle; 1 == end; 2 == beginning;
    public int position = 0;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public GameObject CheckForFrontConveyor()
    {
        //the end object should never change what their next object is
        if (position == 1)
        {
            return nextConveyorBelt;
        }
        Debug.DrawRay(
            transform.position + new Vector3(0, 0.05f, 0),
            Quaternion.Euler(transform.rotation.eulerAngles) * new Vector3(-1, 0, 0),
            Color.blue,
            3f
        );

        RaycastHit hit;
        Ray ray = new Ray(
            transform.position + new Vector3(0, 0.05f, 0),
            Quaternion.Euler(transform.rotation.eulerAngles) * new Vector3(-1, 0, 0)
        );
        Physics.Raycast(ray, out hit, 2f);

        if (
            !hit.collider.IsUnityNull()
            && hit.collider.gameObject.layer == LayerMask.NameToLayer("ConveyorBelt")
            && hit.collider.gameObject.GetComponent<MeshRenderer>().material.GetInt("_isPreview")
                == 0
        )
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    public void OnBuild()
    {
        nextConveyorBelt = CheckForFrontConveyor();
        Invoke("TransferCarriedObjecs", 1f * speedModifier);
    }

    void TransferCarriedObjecs()
    {
        if (nextConveyorBelt.IsUnityNull() || nextConveyorBelt == null)
        {
            nextConveyorBelt = CheckForFrontConveyor();
        }
        else
        {
            ConveyorBelt next = nextConveyorBelt.GetComponent<ConveyorBelt>();
            if (next.carriedObjects[2] == null)
            {
                next.carriedObjects[2] = carriedObjects[0];
                carriedObjects[0] = null;
            }
        }

        for (int i = 0; i < carriedObjects.Length - 1; i++)
        {
            if (carriedObjects[i] == null)
            {
                carriedObjects[i] = carriedObjects[i + 1];
                carriedObjects[i + 1] = null;
            }
        }
        Invoke("TransferCarriedObjecs", 1f * speedModifier);
    }
}
