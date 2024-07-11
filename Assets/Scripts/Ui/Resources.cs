using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Resources : MonoBehaviour
{
    private Dictionary<string, int> storage;
    private UQueryState<Label> labels;
    private int labelsCount;

    void OnEnable()
    {
        storage = GameObject
            .FindGameObjectWithTag("WorldController")
            .GetComponent<BuildingResourceHandler>()
            .storage;
        labels = GetComponent<UIDocument>()
            .rootVisualElement.Query("GrindElement")
            .Children<Label>()
            .Build();
        labelsCount = labels.Count();
    }

    void Update()
    {
        for (int i = 0; i < labelsCount; i++)
        {
            KeyValuePair<string, int> resource = storage.ElementAt(i);
            labels.AtIndex(i).text = resource.Key + ": " + resource.Value;
        }
    }
}
