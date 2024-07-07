using System.Collections.Generic;
using UnityEngine;

public class Container : Building
{
    public GameObject inputObj;
    public GameObject outputObj;
    private ConveyorBelt outputConveyor;
    private ConveyorBelt inputConveyor;

    public string resourceType;
    public int storedLimit = 100;
    public int storedAmount = 0;
    public GameObject outputModel;

    public Dictionary<string, int> buildingResourceHandler;

    private bool isBuild = false;

    public override void OnBuild()
    {
        isBuild = true;
        outputConveyor = outputObj.GetComponent<ConveyorBelt>();
        inputConveyor = inputObj.GetComponent<ConveyorBelt>();
        buildingResourceHandler = GameObject
            .FindWithTag("WorldController")
            .GetComponent<BuildingResourceHandler>()
            .storage;
    }

    void OutputResource()
    {
        buildingResourceHandler[resourceType]--;
        storedAmount--;
        GameObject producedResource = outputModel;
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

    void TakeInResource()
    {
        buildingResourceHandler[resourceType]++;
        storedAmount++;
        Destroy(inputConveyor.carriedObjects[0]);
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void OnDestroyCustom()
    {
        buildingResourceHandler[resourceType] =- storedAmount;
    }

    protected override void Update()
    {
        base.Update();
        if (isBuild)
        {
            if (storedAmount < storedLimit && inputConveyor.carriedObjects[0] != null)
            {
                if (resourceType == "" || resourceType == null)
                {
                    if (!buildingResourceHandler.ContainsKey(resourceType))
                    {
                        buildingResourceHandler.Add(resourceType, 0);
                    }
                    resourceType = inputConveyor.carriedObjects[0].tag;
                    TakeInResource();
                }
                else if (inputConveyor.carriedObjects[0].CompareTag(resourceType))
                {
                    TakeInResource();
                }
            }

            if (storedAmount > 0 && outputConveyor.carriedObjects[2] == null)
            {
                OutputResource();
            }
        }
    }
}
