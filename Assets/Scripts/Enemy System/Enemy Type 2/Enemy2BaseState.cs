using UnityEngine;

public abstract class Enemy2BaseState
{
    protected NewEnemy newEnemy;
    protected Enemy2StateManager enemy2StateManager;
    protected EnemyType2 enemyType2;
    
    public abstract void EnterState(Enemy2StateManager enemy2StateManager);
    
    public abstract void UpdateState(Enemy2StateManager enemy2StateManager);
    
    public abstract void OnCollisionEnter(Enemy2StateManager enemy2StateManager, Collision collision);
}
