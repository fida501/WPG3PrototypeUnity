using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2StateManager : MonoBehaviour
{
    Enemy2BaseState currentState;
    public Enemy2IdleState enemy2IdleState = new Enemy2IdleState();
    public Enemy2FiringState enemy2FiringState = new Enemy2FiringState();
    

    // Start is called before the first frame update
    void Start()
    {
        currentState = enemy2IdleState;
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

    public void SwitchState(Enemy2BaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
