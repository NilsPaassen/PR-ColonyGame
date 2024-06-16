using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSunrotation : MonoBehaviour
{
    
    Vector3 axis = new Vector3(1,0,0);
    void Update()
    {
        transform.Rotate(axis, 0.01f);
    }
}
