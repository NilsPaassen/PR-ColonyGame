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
    }
}
