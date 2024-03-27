using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusType2IdleState : EnemyBaseState
{
    public GusType2IdleState(EnemyBase enemy, EnemyStateMachine2 enemyStateMachine2) : base(enemy, enemyStateMachine2)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (enemy.IsTriggered)
        {
            enemyStateMachine2.ChangeState(enemy.Type2FiringState);
        }

        if (enemy.IsChased)
        {
            enemyStateMachine2.ChangeState(enemy.Type3RunawayState);
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
}