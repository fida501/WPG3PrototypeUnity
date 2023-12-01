using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Weapon weapon;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && weapon.CanShoot())
        {
            weapon.Shoot();
        }
    }
}