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
    }
}
