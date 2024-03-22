using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyController : MonoBehaviour
{
    public GameObject playerDetector;
    public GameObject player;
//    public PlayManager playManager;
    public int enemyType = 0;
    public float currentPositionX;

    [Header("Enemy Type 2")] public Weapon weapon;

    [Header("Enemy Type 3")] public float runAwayDistance = 10.0f;
    public float runAwaySpeed = 5.0f;
    private bool hasRunAway = false;
    private bool timeToRunAway = false;
    private float initialXPosition;

    private void Start()
    {
        initialXPosition = transform.position.x;
    }

    private void Update()
    {
        currentPositionX = transform.position.x;
        if (enemyType == 2)
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

        if (enemyType == 3)
        {
            if (playerDetector != null)
            {
                Collider detectorCollider = playerDetector.GetComponent<Collider>();
                if (detectorCollider != null)
                {
                    // Check for collisions with the player
                    if (detectorCollider.bounds.Intersects(player.GetComponent<Collider>().bounds) && !hasRunAway)
                    {
                        timeToRunAway = true;
                    }
                    if (timeToRunAway)
                    {
                        float targetXPosition = initialXPosition + 15f;
                        EnemyRunningAway(runAwaySpeed);
                        if(currentPositionX >= targetXPosition)
                        {
                            timeToRunAway = false;
                            hasRunAway = true;
                        }
                    }
                }
            }
        }
    }

    void EnemyRunningAway(float enemyRunningAwaySpeed)
    {
        transform.Translate(Vector2.left * enemyRunningAwaySpeed * Time.deltaTime);
    }
}