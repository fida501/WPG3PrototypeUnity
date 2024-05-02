using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI bulletRemainingTMP;
    [SerializeField] private Weapon weapon;
    [SerializeField] private int weaponCurrentAmmo;
    [SerializeField] private int weaponAvailableAmmo;
    [SerializeField] private GameObject playHUD;
    
    
    private void Start()
    {
        weapon = player.GetWeapon();
        weaponCurrentAmmo = weapon.weaponCurrentAmmo;
        weaponAvailableAmmo = 120;
    }

    private void Update()
    {
        weaponCurrentAmmo = weapon.weaponCurrentAmmo;
        bulletRemainingTMP.text = weaponCurrentAmmo + "/" + weaponAvailableAmmo;
        if (DialogueManager.GetInstance().IsDialogueIsPlaying)
        {
            playHUD.SetActive(false);
        } else
        {
            playHUD.SetActive(true);
        }   
    }
}
