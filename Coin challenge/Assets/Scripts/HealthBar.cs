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
        if (alife == null) 
        {
            Debug.Log("ialife n'est pas assigné");
            return;
        }
        image.fillAmount = 0.5f;
    }
}
