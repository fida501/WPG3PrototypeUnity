using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1StateManager : MonoBehaviour
{
    Enemy1BaseState currentState;

    public Enemy1IdleState enemy1IdleState = new Enemy1IdleState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = enemy1IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(Enemy1BaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}