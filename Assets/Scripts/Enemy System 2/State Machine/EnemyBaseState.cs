using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState
{
    protected EnemyBase enemy;
    protected EnemyStateMachine2 enemyStateMachine2;

    public EnemyBaseState(EnemyBase enemy, EnemyStateMachine2 enemyStateMachine2)
    {
        this.enemy = enemy;
        this.enemyStateMachine2 = enemyStateMachine2;
    }

    public virtual void EnterState()
    {
    }

    public virtual void FrameUpdate()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void AnimationTrigger(EnemyBase.AnimationTriggerType triggerType)
    {
    }
}