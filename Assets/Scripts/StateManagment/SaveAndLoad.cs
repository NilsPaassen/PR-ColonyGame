using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public TextAsset initResourceStorage;

    public void NewGame()
    {
        ResetResourceStorage();
    }

    void ResetResourceStorage()
    {
        TextAsset storage = GetComponent<BuildingResourceHandler>().jsonFile;
        File.WriteAllText(
            AssetDatabase.GetAssetPath(storage),
            JsonUtility.ToJson(initResourceStorage.text)
        );
        EditorUtility.SetDirty(storage);
    }
}
