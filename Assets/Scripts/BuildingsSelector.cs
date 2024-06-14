using UnityEngine;
using UnityEngine.UIElements;

public class BuildingsSelector : MonoBehaviour
{
    public GameObject[] buildings;

    private VisualElement buildingsSelector;
    private UQueryState<VisualElement> buildingIcons;
    private EventCallback<ClickEvent>[] buildingIconClickCallbacks;
    private BuildingPlacing buildingPlacing;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        buildingsSelector = root.Q("BuildingsSelector");
        buildingsSelector.RegisterCallback<MouseEnterEvent>(OnBuildingsSelectorMouseEnter);
        buildingsSelector.RegisterCallback<MouseLeaveEvent>(OnBuildingsSelectorMouseLeave);

        int buildingsLength = buildings.Length;
        buildingIcons = root.Query("BuildingIcon").Build();
        buildingIconClickCallbacks = new EventCallback<ClickEvent>[buildingsLength];
        for (int i = 0; i < buildingsLength; i++)
        {
            buildingIconClickCallbacks[i] = OnBuildingIconClick(buildings[i]);
            buildingIcons.AtIndex(i).RegisterCallback(buildingIconClickCallbacks[i]);
        }

        buildingPlacing = GameObject
            .FindGameObjectWithTag("WorldController")
            .GetComponent<BuildingPlacing>();
    }

    void OnDisable()
    {
        buildingsSelector.UnregisterCallback<MouseEnterEvent>(OnBuildingsSelectorMouseEnter);
        buildingsSelector.UnregisterCallback<MouseLeaveEvent>(OnBuildingsSelectorMouseLeave);
        for (int i = 0; i < buildings.Length; i++)
        {
            buildingIcons.AtIndex(i).UnregisterCallback(buildingIconClickCallbacks[i]);
        }
    }

    private void OnBuildingsSelectorMouseEnter(MouseEnterEvent evt)
    {
        buildingPlacing.pauseBuildMode();
    }

    private void OnBuildingsSelectorMouseLeave(MouseLeaveEvent evt)
    {
        buildingPlacing.resumeBuildMode();
    }

    private EventCallback<ClickEvent> OnBuildingIconClick(GameObject building)
    {
        return (evt) =>
        {
            buildingPlacing.selectedBuilding = building;
            buildingPlacing.enableBuildMode();
        };
    }
}
