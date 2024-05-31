using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
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
        if (position == 1) {
            return nextConveyorBelt;
         }

        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        Physics.Raycast(ray, out hit, 1f);
        if (hit.collider && hit.collider.gameObject.layer == LayerMask.NameToLayer("ConveyorBelt"))
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

    private void TransferCarriedObjecs()
    {
        if (nextConveyorBelt == null)
        {
            CheckForFrontConveyor();
        }
        if (nextConveyorBelt != null)
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
        Invoke("TransferCarriedObjects", 1f * speedModifier);
    }
}
