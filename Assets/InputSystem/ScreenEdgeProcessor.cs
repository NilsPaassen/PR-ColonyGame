using UnityEngine;
using UnityEngine.InputSystem;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class ScreenEdgeProcessor : InputProcessor<float>
{
    public enum ScreenEdge
    {
        Top,
        Bottom,
        Left,
        Right,
    }

    [Tooltip("Screen edge the mouse needs to be near to.")]
    public ScreenEdge screenEdge;

    [Tooltip("Distance how far away from the screen edge the mouse can be.")]
    public float distance;

    public override float Process(float value, InputControl control)
    {
        float currentDistance = value;
        if (screenEdge == ScreenEdge.Top)
        {
            currentDistance = Screen.height - value;
        }
        else if (screenEdge == ScreenEdge.Right)
        {
            currentDistance = Screen.width - value;
        }
        return Convert.ToSingle(currentDistance >= 0 && currentDistance <= distance);
    }

#if UNITY_EDITOR
    static ScreenEdgeProcessor()
    {
        Initialize();
    }
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        InputSystem.RegisterProcessor<ScreenEdgeProcessor>();
    }
}
