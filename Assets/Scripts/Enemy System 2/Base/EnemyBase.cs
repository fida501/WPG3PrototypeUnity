using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageAble, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }

    #region State Machine Variables
    
    public EnemyStateMachine2 enemyStateMachine2 { get; private set; }
    public GusType2IdleState Type2IdleState { get; private set; }
    public GusType2FiringState Type2FiringState { get; private set; }
    
    public GusType3RunawayState Type3RunawayState { get; private set; }

    #endregion
    
    public Weapon weapon;
    
    
    public bool IsTriggered { get; set; }
    
    public bool IsChased { get; set; }

    private void Awake()
    {
        enemyStateMachine2 = gameObject.AddComponent<EnemyStateMachine2>();
        Type2IdleState = new GusType2IdleState(this, enemyStateMachine2);
        Type2FiringState = new GusType2FiringState(this, enemyStateMachine2);
        Type3RunawayState = new GusType3RunawayState(this, enemyStateMachine2);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        
        enemyStateMachine2.Initialize(Type2IdleState);
    }

    private void Update()
    {
        enemyStateMachine2.currentState.FrameUpdate();
    }
    
    private void FixedUpdate()
    {
        enemyStateMachine2.currentState.PhysicsUpdate();
    }

    #region Health and damage

    public void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    #endregion

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        return;
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged
    }

    public void SetTriggerStatus(bool isTriggered)
    {
        IsTriggered = isTriggered;
    }
    
    public void SetChaseStatus(bool isChased)
    {
        IsChased = isChased;
    }
}

