using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet Damage
    [SerializeField] private float bulletDamage = 50f;
    public float bulletTravelDistance = 10f;
    public Weapon weapon;
    public float traveledDistance;
    private Vector3 bulletStartPosition;
    [SerializeField] private bool isBulletFromPlayer ;
    //
    // private void Start()
    // {
    //     bulletDamage = weapon.bulletDamage;
    // }
    private void Start()
    {
        bulletStartPosition = transform.position;
    }

    private void Update()
    {
        traveledDistance = Vector3.Distance(bulletStartPosition, transform.position); 
        
        if (traveledDistance >= bulletTravelDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroy(other.gameObject);
            Destroy(gameObject);
            //Check the other gameObject's tag, if it has Enemy Script, then call TakeDamage()
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (isBulletFromPlayer)
            {
                return;
            }
            else
            {
                // Destroy(other.gameObject);
                Destroy(gameObject);
                //Check the other gameObject's tag, if it has Enemy Script, then call TakeDamage()
                if (other.gameObject.GetComponent<Player>() != null)
                {
                    other.gameObject.GetComponent<Player>().TakeDamage(bulletDamage);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBulletDamage(float bulletNewDamage)
    {
        bulletDamage = bulletNewDamage;
    }
    public void setBulletTravelDistance(float newBulletTravelDistance)
    {
        bulletTravelDistance = newBulletTravelDistance;
    }
    public void setIsBulletFromPlayer(bool isFromPlayer)
    {
        isBulletFromPlayer = isFromPlayer;
    }
}