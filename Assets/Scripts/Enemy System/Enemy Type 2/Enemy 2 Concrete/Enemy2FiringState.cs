using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2FiringState : Enemy2BaseState
{

    public override void EnterState(Enemy2StateManager enemy2StateManager)  
    {
        Debug.Log("inside this firing state");
    }

    public override void UpdateState(Enemy2StateManager enemy2StateManager)
    {   
        
    }

    public override void OnCollisionEnter(Enemy2StateManager enemy2StateManager, Collision collision)
    {
        
    }
}
