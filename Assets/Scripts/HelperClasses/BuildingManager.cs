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
        return System.Array.Find(subArray, b => b.name == buildingName);
    }

    public JSONStructures.Building GetLogisticBuilding(string buildingName)
    {
        return GetBuilding(buildingName, allBuildings.logisticBuildings);
    }

    public JSONStructures.Building GetResourceGatheringBuilding(string buildingName)
    {
        return GetBuilding(buildingName, allBuildings.resourceGatheringBuildings);
    }

    public JSONStructures.Building GetEnergyBuilding(string buildingName)
    {
        return GetBuilding(buildingName, allBuildings.energyBuildings);
    }

    public JSONStructures.Building GetSettelerBuilding(string buildingName)
    {
        return GetBuilding(buildingName, allBuildings.settlerBuildings);
    }
}
