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
    private Animator _animator;
    [SerializeField] private Weapon weapon;


    private void Start()
    {
        _animator = GetComponent<Animator>();
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

    private void OnEnable()
    {
        DialogueManager.GetInstance().OnDialogueTriggere += HandleDialogue;
    }

    private void OnDisable()
    {
        DialogueManager.GetInstance().OnDialogueTriggere -= HandleDialogue;
    }

    private void HandleDialogue(TextAsset dialogueFile)
    {
        _animator.SetFloat("PlayerSpeed", 0);
        DialogueManager.GetInstance().StartDialogue(dialogueFile);
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }
    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
}