using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;

    public void SetStartExp(int exp)
    {
        slider.minValue = exp;
        slider.value = exp;


    }

    public void SetExp(int exp)
    {
        slider.value = exp;


    }

}
