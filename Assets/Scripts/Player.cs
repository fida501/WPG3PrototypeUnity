using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Player Class, it has health
    [SerializeField] private float health = 100f;
    public Slider slider;
    public PlayManager playManager;


    private void Start()
    {
        setMaxHealth(health);
    }

    private void Update()
    {
        setHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            playManager.currentCondition = "Lose";
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;   
    }

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }
}