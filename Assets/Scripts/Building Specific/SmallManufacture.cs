using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SmallManufacture : MonoBehaviour
{
    public GameObject inputCBObject;
    public GameObject outputCBObject;

    private ConveyorBelt input;
    private ConveyorBelt output;

    private String selectedProduct = "Cable";

    private int storedResources = 0;
    private int storedResourcesLimit = 100;
    private int storedProduct = 0;
    private int storedProductLimit = 100;

    public int producedResourceAmount = 5;
    public int requiredResources = 1;


    private bool productionIsInvoked = false;
    private bool isBuild = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBuild)
        {
            if (storedResources<storedResourcesLimit &&input.carriedObjects[0] != null && CheckIfResourceIsRequired(input.carriedObjects[0].tag))
        {
            Destroy(input.carriedObjects[0]);
            storedResources++;
        }
        if(!productionIsInvoked && storedResources>=requiredResources){
            productionIsInvoked = true;
            Invoke("ProduceResource",1f);
        }
        if (storedProduct>0 && output.carriedObjects[2] == null)
        {
            GameObject outputProduct = new GameObject(selectedProduct);
            outputProduct.tag = selectedProduct;
            output.carriedObjects[2] = outputProduct;
            storedProduct--;
        }
        }
        
    }

    public void ProduceResource(){
        storedResources = storedResources-requiredResources;
        storedProduct = storedProduct + producedResourceAmount;
        productionIsInvoked = false;
    }


    private bool CheckIfResourceIsRequired(String pArrivingResource)
    {
        switch (selectedProduct)
        {
            case "Cable":
                return pArrivingResource == "CopperBar";

            default:
                return false;
        }

    }

    public void OnBuild()
    {
        input = inputCBObject.GetComponent<ConveyorBelt>();
        output = outputCBObject.GetComponent<ConveyorBelt>();
        isBuild = true;
        input.OnBuild();
        output.OnBuild();
    }

}
