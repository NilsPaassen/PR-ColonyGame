using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public virtual void OnBuild() { }

    public virtual void OnBuild(String param) { }

    protected virtual void Update() { }

    protected virtual void Start() { }
}
