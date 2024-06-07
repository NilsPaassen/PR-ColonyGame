using UnityEngine;
using UnityEngine.UIElements;

public class NavbarController : MonoBehaviour
{
    private VisualElement root;

    void OnEnable()
    {
        // UXML und USS laden
        var visualTree = Resources.Load<VisualTreeAsset>("NavbarLayout");
        var styleSheet = Resources.Load<StyleSheet>("NavbarStyle");

        root = visualTree.CloneTree();
        root.styleSheets.Add(styleSheet);

        // Zum UI hinzufügen
        var uiDocument = GetComponent<UIDocument>();
        uiDocument.rootVisualElement.Add(root);

        // Bilder hinzufügen
        string[] iconPaths =
        {
            "Assets/UI/Icons/CoalOre.webp",
            "Assets/UI/Icons/IronOre.webp",
            "Assets/UI/Icons/GoldOre.webp",
            "Assets/UI/Icons/HammerIcon.png",
            "Assets/UI/Icons/Haus_Icon.png",
            "Assets/UI/Icons/Kleine_Mine.png",
            "Assets/UI/Icons/Kleine_Fabrik_Icon.png",
            "Assets/UI/Icons/Schmelze_Icon.png",
            "Assets/UI/Icons/Flieband_Icon.png"
        };

        var iconElements = root.Query<VisualElement>(className: "icon-container").ToList();
        for (int i = 0; i < iconElements.Count; i++)
        {
            var icon = new Image();
            icon.image = LoadImage(iconPaths[i]);
            iconElements[i].Add(icon);
        }
    }

    private Texture2D LoadImage(string path)
    {
        Texture2D texture = new Texture2D(2, 2);
        byte[] imageData = System.IO.File.ReadAllBytes(path);
        texture.LoadImage(imageData);
        return texture;
    }
}
