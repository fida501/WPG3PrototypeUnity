using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement;
    public Weapon weapon;
    public Player player;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (DialogueManager.GetInstance().IsDialogueIsPlaying)
        {
            return;
        }

        if (Input.GetMouseButton(0) && weapon.CanShoot() && weapon.weaponCurrentAmmo > 0)
        {
            weapon.Shoot(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (player.GetPlayerAmmoRemain() <= 0)
            {
                return;
            }
            else
            {
                player.PlayerReloadWeapon();
            }
        }
    }
}