using UnityEngine;
using UnityEngine.UIElements;

public class ModeIndicator : MonoBehaviour
{
    private BuildingPlacing buildingPlacing;
    private Mode currentMode;
    private VisualElement selectMode;
    private VisualElement buildMode;
    private VisualElement destroyMode;

    void OnEnable()
    {
        buildingPlacing = GameObject
            .FindGameObjectWithTag("WorldController")
            .GetComponent<BuildingPlacing>();
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        selectMode = root.Q("SelectMode");
        buildMode = root.Q("BuildMode");
        destroyMode = root.Q("DestroyMode");
    }

    void Update()
    {
        Mode newMode = buildingPlacing.GetMode();
        if (currentMode == newMode) {
            return;
        }
        selectMode.AddToClassList("hidden");
        buildMode.AddToClassList("hidden");
        destroyMode.AddToClassList("hidden");
        switch(newMode) {
            case Mode.Select:
                selectMode.RemoveFromClassList("hidden");
                break;
            case Mode.Build:
                buildMode.RemoveFromClassList("hidden");
                break;
            case Mode.Destroy:
                destroyMode.RemoveFromClassList("hidden");
                break;
        }
        currentMode = newMode;
    }
}
