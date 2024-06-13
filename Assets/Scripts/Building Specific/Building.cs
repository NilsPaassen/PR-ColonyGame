using System;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
   virtual public void OnBuild() { }
   virtual public void OnBuild(String param) { }
}
