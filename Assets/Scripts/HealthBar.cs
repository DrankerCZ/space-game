using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider slider;
    [SerializeField] Image fill;
    [SerializeField] Gradient gradient;
    void Start()
    {
        IStats stats = GetComponentInParent<IStats>();
        if (stats != null)
        {
            slider.maxValue = stats.GetMaxHealth();
            slider.value = stats.GetHealth();
            fill.color = gradient.Evaluate(1);
            stats.AddOnTakeDamage(() =>
            {
                slider.value = stats.GetHealth();
                fill.color = gradient.Evaluate(stats.GetHealth() / stats.GetMaxHealth());
            });
        }
    }

    private void LateUpdate()
    {
        this.transform.rotation = Quaternion.identity;
    }
}
