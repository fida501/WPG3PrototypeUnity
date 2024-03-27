using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private NewEnemy newEnemy;
    private EnemyType2 enemyType2;

    private void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        newEnemy = GetComponentInParent<NewEnemy>();
        enemyType2 = GetComponentInParent<EnemyType2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerTarget)
        {
            enemyType2.SetTriggerStatus(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerTarget)
        {
            enemyType2.SetTriggerStatus(false);
        }
    }
}
