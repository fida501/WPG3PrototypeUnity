
using UnityEngine;

public abstract class Enemy1BaseState
{
    public abstract void EnterState(Enemy1StateManager enemy1StateManager);
    public abstract void UpdateState(Enemy1StateManager enemy1StateManager);
    
    public abstract void OnCollisionEnter(Enemy1StateManager enemy1StateManager, Collision collision);
    
}
