using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public virtual void OnBuild() { }

    public virtual void OnBuild(String param) { }

    List<Material> sunMaterials = new List<Material>();

    GameObject sun;

    protected virtual void Start()
    {
        foreach (Material mat in GetComponent<MeshRenderer>().materials)
        {
            if (mat.HasFloat("_sunValue"))
            {
                sunMaterials.Add(mat);
            }
        }

        sun = GameObject.FindGameObjectWithTag("Sun");
    }

    protected virtual void Update()
    {
        //SetSunColor();
    }

    void SetSunColor()
    {
        foreach (Material mat in sunMaterials)
        {
            mat.SetFloat("_sunValue", sun.transform.rotation.eulerAngles.x % 360 < 180 ? 0.5f : 0);
        }
    }
}
