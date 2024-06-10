using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public TextAsset jsonFile; // Assign the JSON file in the Unity Inspector

    private JSONStructures.AllBuildings allBuildings;

    void Start()
    {
        // Parse the JSON file
        allBuildings = JsonUtility.FromJson<JSONStructures.AllBuildings>(jsonFile.text);
    }

    JSONStructures.Building GetBuilding(string buildingName, JSONStructures.Building[] subArray)
    {
        return System.Array.Find<JSONStructures.Building>(subArray, b => b.name == buildingName);
    }

    JSONStructures.Building GetLogisticBuilding(string buildingName)
    {
        return GetBuilding(buildingName, allBuildings.logisticBuildings);
    }

    JSONStructures.Building GetResourceGatheringBuilding(string buildingName)
    {
        return GetBuilding(buildingName, allBuildings.resourceGatheringBuildings);
    }

    JSONStructures.Building GetEnergyBuilding(string buildingName)
    {
        return GetBuilding(buildingName, allBuildings.energyBuildings);
    }

    JSONStructures.Building GetSettelerBuilding(string buildingName)
    {
        return GetBuilding(buildingName, allBuildings.settlerBuildings);
    }
}
