using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Player Class, it has health
    [SerializeField] private int health = 100;
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

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }
}