using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerCheck2 : MonoBehaviour
{
    public GameObject PlayerTarget { get;  set; }
    private EnemyBase enemyBase;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        enemyBase = GetComponentInParent<EnemyBase>();
    }
    
    private void OnTriggerEnter(Collider collission)
    {
        if (collission.gameObject == PlayerTarget)
        {
            enemyBase.SetTriggerStatus(true);
        }
        
    }
    private void OnTriggerExit(Collider collission)
    {
        if (collission.gameObject == PlayerTarget)
        {
            enemyBase.SetTriggerStatus(false);
        }
    }
}
