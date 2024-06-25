using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSunrotation : MonoBehaviour
{
    Light lightComp;

    public float timeScale = 1f;

    public int lightOffset = 5400;
    public int lightScale = 1;

    private bool isDay = true;

    void Start()
    {

        lightComp = GetComponent<Light>();
        //Invoke("DayNightCicle", 480);
    }

    void Update()
    {
        //Debug.Log(Mathf.Sin(Time.fixedTime * timeScale) * lightScale + lightOffset);
        lightComp.colorTemperature = Mathf.Sin(Time.fixedTime * timeScale) * lightScale + lightOffset;
    }

    public void DayNightCicle()
    {
        if (isDay)
        {
            lightComp.colorTemperature = 10000;
            isDay = false;
        }
        else
        {
            lightComp.colorTemperature = 5400;
            isDay = true;
        }
        Invoke("DayNightCicle", 480);
    }
}
