using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildingResourceHandler : MonoBehaviour
{
    public Dictionary<string, int> storage = new Dictionary<string, int>();

    public TextAsset jsonFile;

    void Start()
    {
        Debug.Log(jsonFile);
        foreach (
            JSONStructures.Resource r in JsonUtility
                .FromJson<JSONStructures.Resources>(jsonFile.text)
                .resources
        )
        {
            
            storage.Add(r.resourceName, r.amount);
        }
        if (storage.TryGetValue("IronBar",out int value))
        {
            Debug.Log(value);
        }
        
    }

    public void OnSave()
    {
        JSONStructures.Resource r = new JSONStructures.Resource();
        JSONStructures.Resource[] resources = new JSONStructures.Resource[storage.Count];
        int i = 0;
        foreach (KeyValuePair<string, int> entry in storage)
        {
            r.resourceName = entry.Key;
            r.amount = entry.Value;
            resources[i] = r;
            i++;
        }
        JSONStructures.Resources jsonResources = new JSONStructures.Resources();
        jsonResources.resources = resources;

        File.WriteAllText(AssetDatabase.GetAssetPath(jsonFile), JsonUtility.ToJson(jsonResources));
        EditorUtility.SetDirty(jsonFile);
    }
}
