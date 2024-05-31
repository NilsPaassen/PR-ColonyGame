using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class RelateVector2ToScreenProcessor : InputProcessor<Vector2>
{
    [Tooltip("Value when incoming Vector2's components match the size of the whole screen.")]
    public float wholeScreenValue;

    public override Vector2 Process(Vector2 value, InputControl control)
    {
        return wholeScreenValue / Mathf.Min(Screen.width, Screen.height) * value;
    }

#if UNITY_EDITOR
    static RelateVector2ToScreenProcessor()
    {
        Initialize();
    }
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        InputSystem.RegisterProcessor<RelateVector2ToScreenProcessor>();
    }
}
