using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public TextAsset jsonFile; // Assign the JSON file in the Unity Inspector

    private JSONStructures.AllBuildings allRecipes;

    void Start()
    {
        // Parse the JSON file
        allRecipes = JsonUtility.FromJson<JSONStructures.AllBuildings>(jsonFile.text);
    }
}
