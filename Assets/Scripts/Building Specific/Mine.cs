using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject outputConveyorObject;
    private ConveyorBelt outputConveyor;

    private int resourcesStored;

    public String resourceType;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnResourceProduced() { }

    public void OnBuild(String groundType)
    {
        resourceType = groundType;
        outputConveyor = outputConveyorObject.GetComponent<ConveyorBelt>();
    }
}
