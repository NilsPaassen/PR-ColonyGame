using System.Collections.Generic;
using UnityEngine;

public class BuildingResourceHandler : MonoBehaviour
{
    public Dictionary<string, int> storage = new Dictionary<string, int>();

    void Start() { 
        storage.Add("CopperOre",0);
        storage.Add("IronOre",0);
        storage.Add("CopperBar",0);
        storage.Add("IronBar",0);
        storage.Add("SteelBar",0);
        storage.Add("Coal",0);
        storage.Add("Cable",0);
    }
}
