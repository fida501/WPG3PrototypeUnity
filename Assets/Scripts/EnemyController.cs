using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject playerDetector;
    public GameObject player;
    public Weapon weapon;
    public PlayManager playManager;

    private void Update()
    {
        if (playerDetector != null)
        {
            Collider detectorCollider = playerDetector.GetComponent<Collider>();
            if (detectorCollider != null)
            {
                // Check for collisions with the player
                if (detectorCollider.bounds.Intersects(player.GetComponent<Collider>().bounds))
                {
                    // If the player is in range, shoot
                    if (weapon.CanShoot())
                    {
                        weapon.Shoot(1);
                    }
                }
            }
        }
    }
}