using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider health;
    public Image fill;

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }

    public void setMaxHealth(float hp)
    {
        health.maxValue = hp;
        health.value = hp;
    }

    public void setHealth(float hp)
    {
        health.value = hp;
    }
}
