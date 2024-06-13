using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public TextAsset jsonFile; // Assign the JSON file in the Unity Inspector

    private JSONStructures.AllRecipes allRecipes;

    void Start()
    {
        // Parse the JSON file
        allRecipes = JsonUtility.FromJson<JSONStructures.AllRecipes>(jsonFile.text);
    }

    JSONStructures.Recipe GetRecipe(string recipeName, JSONStructures.Recipe[] subArray)
    {
        return System.Array.Find(subArray, b => b.name == recipeName);
    }

    public JSONStructures.Recipe GetSmelterRecipe(string recipeName)
    {
        return GetRecipe(recipeName, allRecipes.smelterRecipe);
    }

    public JSONStructures.Recipe GetSingleInputFactoryRecipe(string recipeName)
    {
        return GetRecipe(recipeName, allRecipes.singleInputFactoryRecipes);
    }

    public JSONStructures.Recipe GetDualInputFactoryRecipe(string recipeName)
    {
        return GetRecipe(recipeName, allRecipes.dualInputFactoryRecipes);
    }
}
