using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerRunaway : MonoBehaviour
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
            enemyBase.SetChaseStatus(true);
        }
        
    }
    private void OnTriggerExit(Collider collission)
    {
        if (collission.gameObject == PlayerTarget)
        {
            
        }
    }
}
