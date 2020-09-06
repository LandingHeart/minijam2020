﻿using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float health)
    {

        slider.maxValue = health;
        slider.value = health;
    }
    public void setHealth(float health)
    {
        slider.value = health;
    }
    // Start is called before the first frame updat
}
