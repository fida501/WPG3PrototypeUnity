using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusType3RunawayState : EnemyBaseState
{
    private float _initialXPosition;
    private float _currentXPosition;
    private float _targetXPosition;
    private GusRunaway _gusRunaway;

    public GusType3RunawayState(EnemyBase enemy, EnemyStateMachine2 enemyStateMachine2) : base(enemy,
        enemyStateMachine2)
    {
        _gusRunaway = enemy as GusRunaway;
    }

    public override void EnterState()
    {
        base.EnterState();
        _initialXPosition = enemy.transform.position.x;
        _targetXPosition = _initialXPosition + 15;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        _currentXPosition = enemy.transform.position.x;
        EnemyRunningAway(_gusRunaway.runawaySpeed);

        if (_currentXPosition >= _targetXPosition)
        {
            _gusRunaway.runawaySpeed = 0f;
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