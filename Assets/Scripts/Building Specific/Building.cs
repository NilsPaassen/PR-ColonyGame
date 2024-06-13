using System;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public virtual void OnBuild() { }

    public virtual void OnBuild(String param) { }
}
