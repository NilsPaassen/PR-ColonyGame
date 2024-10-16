using System;
using UnityEngine;

public class JSONStructures : MonoBehaviour
{
    [Serializable]
    public class Building
    {
        public string name;
        public Resource[] cost;
        public int worker;
        public int energyConsumed;
        public int energyProduced;
        public int livingSpace;
    }

    [Serializable]
    public class PlacedBuilding
    {
        public Transform transform;
        public Factory factory;
    }

    [Serializable]
    public class Resource
    {
        public string resourceName;
        public int amount;
    }

    [Serializable]
    public class Resources
    {
        public Resource[] resources;
    }

    [Serializable]
    public class Recipe
    {
        public string name;
        public Resource[] input;
        public Resource output;
    }

    [Serializable]
    public class AllBuildings
    {
        public Building[] logisticBuildings;
        public Building[] resourceGatheringBuildings;
        public Building[] energyBuildings;
        public Building[] settlerBuildings;
        public Building[] productionBuildings;
    }

    [Serializable]
    public class AllRecipes
    {
        public Recipe[] smelterRecipe;
        public Recipe[] singleInputFactoryRecipes;
        public Recipe[] dualInputFactoryRecipes;
    }
}
