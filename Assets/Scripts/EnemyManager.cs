using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public PlayManager playManager;

    private void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                enemies.Remove(enemy);
            }
        }

        if (enemies.Count == 0)
        {
            // Win
            playManager.currentCondition = "Win";
        }
    }
}