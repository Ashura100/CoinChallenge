using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image image;
    IAlife alife;
    float lifeRate
    {
        get
        {
            return (float)alife.health / (float)alife.maxHealth;
        }
    }
    public void Init(IAlife alife)
    {
        this.alife = alife;
    }

    public void UpdateHealth()
    {
        image.fillAmount = lifeRate;
    }
}
