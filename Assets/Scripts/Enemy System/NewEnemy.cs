using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour, IDamageAble, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    
    public bool IsTriggered { get; set; }


    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    public void SetTriggerStatus(bool isTriggered)
    {
        IsTriggered = isTriggered;
    }

    public bool IsChased { get; set; }
    public void SetChaseStatus(bool isChased)
    {
        throw new NotImplementedException();
    }
}