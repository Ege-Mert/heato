using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatingBar : MonoBehaviour
{
    public Slider heatBarSlider;

    public void SetMaxHeat(float heat){
        heatBarSlider.maxValue = heat;
        heatBarSlider.value = heat;
    }

    public void SetHeat(float heat){
        heatBarSlider.value = heat;
    }
}
