using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusType2FiringState : EnemyBaseState
{
    public GusType2FiringState(EnemyBase enemy, EnemyStateMachine2 enemyStateMachine2) : base(enemy, enemyStateMachine2)
    {
        
    }


    public override void EnterState()
    {
        base.EnterState();
        if (enemy.weapon.weaponCurrentAmmo == 0)
        {
            enemy.weapon.setWeaponAmmo(30);
        } 
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (enemy.weapon.weaponCurrentAmmo == 0)
        {
            enemy.weapon.Reload();
        }

        if (enemy.weapon.CanShoot())
        {
            enemy.weapon.Shoot(1);
        }

        if (enemy.IsTriggered == false)
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
}