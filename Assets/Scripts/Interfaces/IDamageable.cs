using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble
{
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
    void TakeDamage(float damageAmount);
    void Die();
}
