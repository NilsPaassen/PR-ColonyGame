using System;
using UnityEngine;

public class Mine : Building
{
    public GameObject outputConveyorObject;
    private ConveyorBelt outputConveyor;

    private int resourcesStored;

    public int resourceLimit = 100;

    public GameObject barModel;

    public String resourceType;

    //Production Timer
    public float productionTime = 10f;
    public float remainigTimeTillProduction = 10f;

    public bool isBuild = false;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isBuild)
        {
            if (remainigTimeTillProduction <= 0 && resourcesStored < resourceLimit)
            {
                resourcesStored++;
                remainigTimeTillProduction = productionTime;
            }
            else if (remainigTimeTillProduction > 0)
            {
                Debug.Log(resourcesStored);
                remainigTimeTillProduction -= Time.deltaTime;
            }
            if (resourcesStored > 0 && outputConveyor.carriedObjects[2] == null)
            {
                OutputResource();
            }
        }
    }

    void OutputResource()
    {
        GameObject producedResource = barModel;
        outputConveyor.carriedObjects[2] = Instantiate(
            producedResource,
            outputConveyor.transform.position
                - Quaternion.Euler(outputConveyor.transform.rotation.eulerAngles)
                    * new Vector3(-0.35f, 0, 0)
                + new Vector3(0, .2f, 0),
            Quaternion.identity
        );
        outputConveyor.carriedObjects[2].tag = resourceType;
        resourcesStored--;
    }

    public override void OnBuild(String groundType)
    {
        resourceType = groundType;
        outputConveyor = outputConveyorObject.GetComponent<ConveyorBelt>();
        outputConveyor.OnBuild();
        isBuild = true;
    }
}
