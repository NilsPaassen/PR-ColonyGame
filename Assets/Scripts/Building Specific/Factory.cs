using System;
using Unity.VisualScripting;
using UnityEngine;

public class Factory : Building
{
    public String factoryType = "small";
    public GameObject inputCBObject;
    public GameObject secondaryInputCBObject;
    public GameObject outputCBObject;

    private ConveyorBelt input;
    private ConveyorBelt secondaryInput;
    private ConveyorBelt outputConveyor;

    public String selectedProduct;
    public GameObject outputProductModel;

    public String resource;
    public String secondaryResource;
    private int storedResources = 0;
    private int storedSecondaryResources = 0;
    private int storedResourcesLimit = 100;
    private int storedSecondaryResourcesLimit = 100;
    private int storedProduct = 0;
    public int storedProductLimit = 100;

    public int producedAmount = 5;
    public int requiredResources = 1;
    public int requiredSecondaryResources = 0;

    private bool productionIsInvoked = false;
    private bool isBuild = false;

    // Update is called once per frame
    void Update()
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
                    storedSecondaryResources < storedSecondaryResourcesLimit
                    && secondaryInput.carriedObjects[0] != null
                    && secondaryInput.carriedObjects[0].CompareTag(secondaryResource)
                )
                {
                    Destroy(secondaryInput.carriedObjects[0]);
                    storedResources++;
                }
            }
            if (
                !productionIsInvoked
                && storedResources >= requiredResources
                && storedSecondaryResources >= requiredSecondaryResources
                && storedProduct > storedProductLimit
            )
            {
                productionIsInvoked = true;
                Invoke("ProduceResource", 1f);
            }
            if (storedProduct > 0 && outputConveyor.carriedObjects[2] == null)
            {
                GameObject outputProduct = new GameObject(selectedProduct);
                outputProduct.tag = selectedProduct;
                outputConveyor.carriedObjects[2] = Instantiate(
                    outputProduct,
                    outputConveyor.transform.position
                        - Quaternion.Euler(outputConveyor.transform.rotation.eulerAngles)
                            * new Vector3(-0.35f, 0, 0)
                        + new Vector3(0, .2f, 0),
                    Quaternion.identity
                );
                storedProduct--;
            }
        }
    }

    public void ProduceResource()
    {
        storedResources = -requiredResources;
        storedSecondaryResources = -requiredSecondaryResources;
        storedProduct = +producedAmount;
        productionIsInvoked = false;
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
        Debug.Log("OnBuild executed");
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
