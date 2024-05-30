using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
#if UNITY_EDITOR
using UnityEditor;
#endif


#if UNITY_EDITOR
[InitializeOnLoad]
#endif
[DisplayStringFormat("{modifier}+{up}/{left}/{down}/{right}")]
[DisplayName("Up/Down/Left/Right Composite With One Modifier")]
public class OneModifierVector2Composite : Vector2Composite
{
    [InputControl(layout = "Button")]
    public int modifier;

    public override Vector2 ReadValue(ref InputBindingCompositeContext context)
    {
        if (context.ReadValueAsButton(modifier))
            return base.ReadValue(ref context);
        return default;
    }

    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
        if (context.ReadValueAsButton(modifier))
            return base.EvaluateMagnitude(ref context);
        return default;
    }

    static OneModifierVector2Composite()
    {
        InputSystem.RegisterBindingComposite<OneModifierVector2Composite>();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init() { }
}
