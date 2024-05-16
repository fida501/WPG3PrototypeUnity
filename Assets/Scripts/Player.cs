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
    private Rigidbody _rBody;

    [Header("Inventory")] [SerializeField] private int playerAmmoRemain;
    [SerializeField] private int playerBadges;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        setMaxHealth(health);
        _rBody = GetComponent<Rigidbody>();
        weapon.SetWeaponAmmoRemaining(playerAmmoRemain);
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

    public void SetWeaponAmmo(int ammo)
    {
        weapon.SetWeaponAmmo(ammo);
    }

    public void IncreasePlayerAmmo(int ammo)
    {
        playerAmmoRemain += ammo;
        weapon.SetWeaponAmmoRemaining(playerAmmoRemain);
    }

    public void DecreasePlayerAmmo(int ammo)
    {
        playerAmmoRemain -= ammo;
        weapon.SetWeaponAmmoRemaining(playerAmmoRemain);
    }

    public int GetPlayerAmmoRemain()
    {
        return playerAmmoRemain;
    }

    public void PlayerReloadWeapon()
    {
        int ammoToDecrease;
        if (playerAmmoRemain <= weapon.weaponAmmo && weapon.weaponCurrentAmmo < weapon.weaponAmmo)
        {
            weapon.weaponCurrentAmmo += playerAmmoRemain;
            playerAmmoRemain = 0;
        }
        else
        {
            ammoToDecrease = weapon.weaponAmmo - weapon.weaponCurrentAmmo;
            DecreasePlayerAmmo(ammoToDecrease);
            weapon.weaponCurrentAmmo = weapon.weaponAmmo;
        }

        if (playerAmmoRemain <= 0)
        {
            playerAmmoRemain = 0;
        }
    }

    public void IncreasePlayerBadges(int badge)
    {
        playerBadges += badge;
    }

    public int GetPlayerBadges()
    {
        return playerBadges;
    }
}