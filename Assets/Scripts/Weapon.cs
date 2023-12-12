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
    public float fireRate = 650f;
    public float bulletDamage = 50f;

    private float nextFireTime = 0.0f;
    
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

    public bool CanShoot()
    {
        return Time.time > nextFireTime;
    }

    public void Shoot(int direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

// Set the velocity along the player's forward vector (z-axis)
        bulletRb.velocity = bullet.transform.right * bulletSpeed * direction;
// Destroy the bullet after a certain duration (bulletLifetime)
        Destroy(bullet, bulletLife);
        // Set the cooldown for the next shot
        nextFireTime = Time.time + 0.1f * fireRate;
        
        if (shootingAudioSource != null && shootingSFX != null)
        {
            shootingAudioSource.PlayOneShot(shootingSFX);
        }
    }
}