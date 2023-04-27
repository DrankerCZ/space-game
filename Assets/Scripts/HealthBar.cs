using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider health;
    public Gradient gradient;
    public Image fill;

    public void setMaxHealth(float hp)
    {
        health.maxValue = hp;
        health.value = hp;

        fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(float hp)
    {
        health.value = hp;

        fill.color = gradient.Evaluate(health.normalizedValue);
    }
}
