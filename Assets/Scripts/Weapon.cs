using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    //[Header("Weapon Position")]
    // public Transform player; // Reference to the player character.
    // public Camera mainCamera; // Reference to the main camera.
    // public float rotationX; // The rotation of the weapon around the X axis.
    // public float rotationY; // The rotation of the weapon around the Y axis.
    // public float rotationZ; // The rotation of the weapon around the Z axis.
    //Vector3 position; // The original position of the weapon.
    // Transform weaponTransform; // Reference to the weapon's transform.
    // private Quaternion targetRotation;
    // public GameObject weapon;

    [Header("Bullet")] public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = -10f;
    public float bulletLife = 2.5f;
    public float weaponRPM;
    public float timePerShot;
    public float bulletDamage = 50f;
    public float bulletDistance = 5f;
    public GameObject bullet;
    public bool isPlayerHoldingWeapon;
    //public GameObject bulletShootEffect;
    [SerializeField] private GameObject bulletShootEffect;
    [SerializeField] private GameObject bulletShootEffectRespawnPoint;
    
    
    [Header("Ammo")] public int weaponAmmo;
    public int weaponCurrentAmmo;
    [SerializeField] private int ammoRemaining;


    public float weaponReloadTime = 2f;

    //private float nextFireTime = 0.0f;
    [SerializeField] private float nextFireTime = 0.0f;

    [Header("SFX")]
    // Reference to the AudioSource component for shooting SFX
    public AudioSource shootingAudioSource;

    public AudioClip shootingSFX;


    private void Awake()
    {
        //position = transform.position; // Store the original position of the weapon.
        // Debug.Log("position: " + position);
        // Debug.Log(weapon.transform.position);
    }

    private void Start()
    {
        timePerShot = 60 / weaponRPM;
        // Transform parent = transform.parent;
        // while (parent != null)
        // {
        //     if (parent.GetComponent<Player>() != null)
        //     {
        //         isPlayerHoldingWeapon = true;
        //         bulletPrefab.GetComponent<Bullet>().setIsBulletFromPlayer(true);
        //         break;
        //     }
        //
        //     parent = parent.parent;
        // }
        weaponCurrentAmmo = weaponAmmo;
    }

    public bool CanShoot()
    {
        return Time.time > nextFireTime;
    }

    public void Shoot(int direction)
    {
        if (weaponCurrentAmmo > 0)
        {
            PlayWeaponShootEffect();
            weaponCurrentAmmo--;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bulletPrefab.GetComponent<Bullet>().SetBulletDamage(bulletDamage);
            bulletPrefab.GetComponent<Bullet>().setBulletTravelDistance(bulletDistance);
            bulletPrefab.GetComponent<Bullet>().setIsBulletFromPlayer(isPlayerHoldingWeapon);
            // if (isPlayerHoldingWeapon)
            // {
            //     bulletPrefab.GetComponent<Bullet>().setIsBulletFromPlayer(true);
            // }
            // else
            // {
            //     bulletPrefab.GetComponent<Bullet>().setIsBulletFromPlayer(false);
            // }
            //        bulletPrefab.GetComponent<Bullet>().setIsBulletFromPlayer(isPlayerHoldingWeapon);
            //        bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            // Set the velocity along the player's forward vector (z-axis)
            bulletRb.velocity = bullet.transform.right * bulletSpeed * direction;
            // Destroy the bullet after a certain duration (bulletLifetime)
            //        Destroy(bullet, bulletLife);
            // Set the cooldown for the next shot
            nextFireTime = Time.time + timePerShot;

            if (shootingAudioSource != null && shootingSFX != null)
            {
                shootingAudioSource.PlayOneShot(shootingSFX);
            }
        }
        else if (weaponCurrentAmmo == 0)
        {
            return;
        }
    }

    public void SetWeaponAmmo(int newAmmo)
    {
        weaponAmmo = newAmmo;
    }

    public void Reload()
    {
        if (weaponCurrentAmmo == 0)
        {
            StartReloadAnimation(0);
        }
        else if (weaponCurrentAmmo < weaponAmmo)
        {
            StartReloadAnimation(1);
        }
    }

    public void StartReloadAnimation(int reloadAnimation)
    {
        // Play the reload animation
        // Reload the weapon
        weaponCurrentAmmo = weaponAmmo;
    }

    public void SetWeaponAmmoRemaining(int ammo)
    {
        ammoRemaining = ammo;
    }

    public void PlayWeaponShootEffect()
    {
//        Instantiate(bulletShootEffect, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        if (bulletShootEffect != null)
        {
            //Instantiate(bulletShootEffect, bulletShootEffect.transform.position ,bulletSpawnPoint.rotation);

            GameObject effect = Instantiate(bulletShootEffect, bulletShootEffectRespawnPoint.transform.position,
                bulletShootEffectRespawnPoint.transform.rotation);
            Destroy(effect, 0.15f);
        }
    }
}