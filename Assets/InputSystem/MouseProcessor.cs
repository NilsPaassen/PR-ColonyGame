using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class MouseProcessor : InputProcessor<Vector2>
{
    [Tooltip("Value when mouse is moved across the whole screen.")]
    public float wholeScreenValue;

    [Tooltip("Scale factor to multiply the mouse movement by on macOS.")]
    public float macOsFactor;

    public override Vector2 Process(Vector2 value, InputControl control)
    {
#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        value *= macOsFactor;
#endif

        return wholeScreenValue / (Mathf.Min(Screen.width, Screen.height) * Time.deltaTime) * value;
    }

#if UNITY_EDITOR
    static MouseProcessor()
    {
        Initialize();
    }
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        InputSystem.RegisterProcessor<MouseProcessor>();
    }
}
