using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxValue(float maxV)
    {
        slider.maxValue = maxV;
        slider.value = maxV;
    }

    public void UpdateValue(float value)
    {
        slider.value = value;
    }
}
