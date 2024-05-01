using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement;
    public Weapon weapon;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (DialogueManager.GetInstance().IsDialogueIsPlaying)
        {
            return;
        }
        
        if (Input.GetMouseButton(0) && weapon.CanShoot())
        {
            weapon.Shoot(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }
    }
}