using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet Damage
    [SerializeField] private int bulletDamage = 50;

    public Weapon weapon;
    //
    // private void Start()
    // {
    //     bulletDamage = weapon.bulletDamage;
    // }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroy(other.gameObject);
            Destroy(gameObject);
            //Check the other gameObject's tag, if it has Enemy Script, then call TakeDamage()
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                Debug.Log("Inside this");
                other.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy(other.gameObject);
            Destroy(gameObject);
            //Check the other gameObject's tag, if it has Enemy Script, then call TakeDamage()
            if (other.gameObject.GetComponent<Player>() != null)
            {
                Debug.Log("Inside this");
                other.gameObject.GetComponent<Player>().TakeDamage(10);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}