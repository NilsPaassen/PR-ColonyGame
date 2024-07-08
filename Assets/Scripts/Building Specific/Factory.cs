using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Factory : Building
{
    public String factoryType = "small";

    //Conveyor Belts
    public GameObject inputCBObject;
    public GameObject secondaryInputCBObject;
    public GameObject outputCBObject;

    private ConveyorBelt input;
    private ConveyorBelt secondaryInput;
    private ConveyorBelt outputConveyor;

    //Resources
    public String selectedProduct;
    public GameObject outputProductModel;
    public String resource;
    public String secondaryResource;
    //Storage
    private int storedResources = 0;
    private int storedSecondaryResources = 0;
    private int storedResourcesLimit = 100;
    private int storedSecondaryResourcesLimit = 100;
    private int storedProduct = 0;
    public int storedProductLimit = 100;
    public int producedAmount = 5;
    public int requiredResources = 1;
    public int requiredSecondaryResources = 0;

    //Production Timer
    public float productionTime = 10f;
    public float remainigTimeTillProduction = 10f;
    private bool isBuild = false;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isBuild)
        {
            if (
                storedResources < storedResourcesLimit
                && input.carriedObjects[0] != null
                && input.carriedObjects[0].CompareTag(resource)
            )
            {
                Destroy(input.carriedObjects[0]);
                storedResources++;
                if (
                    secondaryInput
                    && storedSecondaryResources < storedSecondaryResourcesLimit
                    && secondaryInput.carriedObjects[0] != null
                    && secondaryInput.carriedObjects[0].CompareTag(secondaryResource)
                )
                {
                    Destroy(secondaryInput.carriedObjects[0]);
                    storedResources++;
                }
            }

            if (
                remainigTimeTillProduction <= 0
                && storedResources >= requiredResources
                && storedSecondaryResources >= requiredSecondaryResources
                && storedProduct + producedAmount <= storedProductLimit
            )
            {
                ProduceResource();
            }else if(remainigTimeTillProduction > 0)
            {
                remainigTimeTillProduction -= Time.deltaTime;
            }
            if (storedProduct > 0 && outputConveyor.carriedObjects[2] == null)
            {
                OutputResource();
                storedProduct--;
            }
        }
    }

    public void ProduceResource()
    {
        storedResources = -requiredResources;
        storedSecondaryResources = -requiredSecondaryResources;
        storedProduct = +producedAmount;
        //resets timer
        remainigTimeTillProduction = productionTime;
    }

    void OutputResource()
    {
        GameObject producedResource = outputProductModel;
        outputConveyor.carriedObjects[2] = Instantiate(
            producedResource,
            outputConveyor.transform.position
                - Quaternion.Euler(outputConveyor.transform.rotation.eulerAngles)
                    * new Vector3(-0.35f, 0, 0)
                + new Vector3(0, .2f, 0),
            Quaternion.identity
        );
        outputConveyor.carriedObjects[2].tag = selectedProduct;
    }

    public void SelectSmelterRecipe(String recipeName)
    {
        JSONStructures.Recipe recipe = GameObject
            .FindGameObjectWithTag("WorldController")
            .GetComponent<RecipeManager>()
            .GetSmelterRecipe(recipeName);
        requiredResources = recipe.input[0].amount;
        resource = recipe.input[0].resourceName;
        selectedProduct = recipe.output.resourceName;
        producedAmount = recipe.output.amount;
    }

    public void SelectDualInputRecipe(String recipeName)
    {
        JSONStructures.Recipe recipe = GameObject
            .FindGameObjectWithTag("WorldController")
            .GetComponent<RecipeManager>()
            .GetDualInputFactoryRecipe(recipeName);
        requiredResources = recipe.input[0].amount;
        resource = recipe.input[0].resourceName;
        requiredSecondaryResources = recipe.input[1].amount;
        secondaryResource = recipe.input[1].resourceName;
        selectedProduct = recipe.output.resourceName;
        producedAmount = recipe.output.amount;
    }

    public void SelectSingleInputRecipe(String recipeName)
    {
        JSONStructures.Recipe recipe = GameObject
            .FindGameObjectWithTag("WorldController")
            .GetComponent<RecipeManager>()
            .GetSingleInputFactoryRecipe(recipeName);
        requiredResources = recipe.input[0].amount;
        resource = recipe.input[0].resourceName;
        selectedProduct = recipe.output.resourceName;
        producedAmount = recipe.output.amount;
    }

    public override void OnBuild()
    {
        input = inputCBObject.GetComponent<ConveyorBelt>();
        if (!secondaryInputCBObject.IsUnityNull())
        {
            secondaryInput = secondaryInputCBObject.GetComponent<ConveyorBelt>();
            secondaryInput.OnBuild();
        }

        outputConveyor = outputCBObject.GetComponent<ConveyorBelt>();
        isBuild = true;
        input.OnBuild();
        outputConveyor.OnBuild();
    }
}
