using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2IdleState : Enemy2BaseState
{
    
    public override void EnterState(Enemy2StateManager enemy2StateManager)
    {
        
    }

    public override void UpdateState(Enemy2StateManager enemy2StateManager)
    {
        // if (enemyType2.IsTriggered)
        // {
        //     enemy2StateManager.SwitchState(enemy2StateManager.enemy2FiringState);
        // }
    }

    public override void OnCollisionEnter(Enemy2StateManager enemy2StateManager, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            enemy2StateManager.SwitchState(enemy2StateManager.enemy2FiringState);
        }
    }

}
