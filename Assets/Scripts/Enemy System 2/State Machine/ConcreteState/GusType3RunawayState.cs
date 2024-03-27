using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusType3RunawayState : EnemyBaseState
{
    [SerializeField] private float EnemyRunningAwaySpeed = 5f;
    public float InitialXPosition;
    public float CurrentXPosition;
    public GusType3RunawayState(EnemyBase enemy, EnemyStateMachine2 enemyStateMachine2) : base(enemy, enemyStateMachine2)
    {
    }
    
    public override void EnterState()
    {
        base.EnterState();
        InitialXPosition = enemy.transform.position.x;
    }
    
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        CurrentXPosition = enemy.transform.position.x;
        EnemyRunningAway(EnemyRunningAwaySpeed);
        float targetXPosition = InitialXPosition + 15;
        if (CurrentXPosition >= targetXPosition)
        {
            enemyStateMachine2.ChangeState(enemy.Type2IdleState);
        }
    }
    
    public override void ExitState()
    {
        base.ExitState();
    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    
    public override void AnimationTrigger(EnemyBase.AnimationTriggerType triggerType)
    {
        base.AnimationTrigger(triggerType);
    }
    public void EnemyRunningAway(float enemyRunningAwaySpeed)
    {
        enemy.transform.Translate(Vector2.left * enemyRunningAwaySpeed * Time.deltaTime);
    }
}
