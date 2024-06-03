using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using VSCodeEditor;

public class Mine : MonoBehaviour
{
    public GameObject outputConveyorObject;
    private ConveyorBelt outputConveyor;

    private int resourcesStored;

    public int resourceLimit = 100;

    public String resourceType;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (resourcesStored > 0 && outputConveyor.carriedObjects[2] == null)
        {
            OutputResource();
        }
    }

    void OutputResource()
    {
        GameObject producedResource = new GameObject();
        producedResource.tag = resourceType;
        outputConveyor.carriedObjects[2] = producedResource;
    }

    public void ProduceResource(){
        if (outputConveyor.carriedObjects[2] == null)
        {
            OutputResource();
        }
        else if (resourcesStored < resourceLimit)
        {
            resourcesStored++;
        }

        Invoke("ProduceResource",1f);
    }

    public void OnBuild(String groundType)
    {
        resourceType = groundType;
        outputConveyor = outputConveyorObject.GetComponent<ConveyorBelt>();
        Invoke("ProduceResource",1f);
    }
}
