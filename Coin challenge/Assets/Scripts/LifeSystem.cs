using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour, IAlife
{
    public delegate void OnDie();
    public OnDie onDieDel;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;

    int IAlife.maxHealth
    {
        get
        {
            return this.maxHealth;
        }
    }

    public int health
    {
        get
        {
            return this.currentHealth;
        }
    }

    void Start()
    {
        healthbar.Init(this);
        currentHealth = maxHealth;
        healthbar.UpdateHealth();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(20);
            Debug.Log("perd de la vie");
        }
        Die();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.UpdateHealth();
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            if (onDieDel != null) onDieDel();
        }
    }
}

public interface IAlife
{
    int maxHealth
    {
        get;
    }

    int health
    {
        get;
    }
}
