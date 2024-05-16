using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Class, it has health
    [SerializeField] private float health = 100;


    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Die()
    {
        //Instantiate(itemDropInstatiate, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}