using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine2 : MonoBehaviour
{
    public EnemyBaseState currentState;

    public void Initialize(EnemyBaseState startingState)
    {
        currentState = startingState;
        currentState.EnterState();
    }
    
    public void ChangeState(EnemyBaseState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
    
}