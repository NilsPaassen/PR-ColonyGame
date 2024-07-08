using System;
using UnityEngine;

public class Building : MonoBehaviour
{
    public virtual void OnBuild() { }

    public virtual void OnDestroyCustom() { }

    public virtual void OnBuild(String param) { }

    protected virtual void Update() { }

    protected virtual void Start() { }
}
