using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Factory : Building
{
    public GameObject inputCBObject;
    public GameObject secondaryInputCBObject;
    public GameObject outputCBObject;

    private ConveyorBelt input;
    private ConveyorBelt secondaryInput;
    private ConveyorBelt output;

    public String selectedProduct = "Cable";

    public String resource = "CopperBar";
    public String secondaryResource = "CopperBar";
    private int storedResources = 0;
    private int storedSecondaryResources = 0;
    private int storedResourcesLimit = 100;
    private int storedSecondaryResourcesLimit = 100;
    private int storedProduct = 0;
    private int storedProductLimit = 100;

    public int producedResourceAmount = 5;
    public int requiredResources = 1;
    public int requiredSecondaryResources = 0;

    private bool productionIsInvoked = false;
    private bool isBuild = false;

    // Start is called before the first frame update
    void Start() { }

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
                    Destroy(input.carriedObjects[0]);
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
            if (storedProduct > 0 && output.carriedObjects[2] == null)
            {
                GameObject outputProduct = new GameObject(selectedProduct);
                outputProduct.tag = selectedProduct;
                output.carriedObjects[2] = outputProduct;
                storedProduct--;
            }
        }
    }

    public void ProduceResource()
    {
        storedResources =- requiredResources;
        storedSecondaryResources =- requiredSecondaryResources;
        storedProduct =+ producedResourceAmount;
        productionIsInvoked = false;
    }

    public void OnBuild()
    {
        input = inputCBObject.GetComponent<ConveyorBelt>();
        if (!secondaryInputCBObject.IsUnityNull())
        {
            secondaryInput = secondaryInputCBObject.GetComponent<ConveyorBelt>();
            secondaryInput.OnBuild();
        }

        output = outputCBObject.GetComponent<ConveyorBelt>();
        isBuild = true;
        input.OnBuild();
        output.OnBuild();
    }
}
