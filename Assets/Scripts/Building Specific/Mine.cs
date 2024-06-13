using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using VSCodeEditor;

public class Mine : Building
{
    public GameObject outputConveyorObject;
    private ConveyorBelt outputConveyor;

    private int resourcesStored;

    public int resourceLimit = 100;

    public GameObject barModel;

    public String resourceType;

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
        GameObject producedResource = barModel;
        producedResource.tag = resourceType;
        outputConveyor.carriedObjects[2] = Instantiate(
            producedResource,
            outputConveyor.transform.position
                - Quaternion.Euler(outputConveyor.transform.rotation.eulerAngles)
                    * new Vector3(-0.35f, 0, 0)
                + new Vector3(0, .2f, 0),
            Quaternion.identity
        );
    }

    public void ProduceResource()
    {
        if (outputConveyor.carriedObjects[2] == null)
        {
            OutputResource();
        }
        else if (resourcesStored < resourceLimit)
        {
            resourcesStored++;
        }

        Invoke("ProduceResource", 1f);
    }

    public override void OnBuild(String groundType)
    {
        resourceType = groundType;
        outputConveyor = outputConveyorObject.GetComponent<ConveyorBelt>();
        Invoke("ProduceResource", 1f);
        outputConveyor.OnBuild();
    }
}
