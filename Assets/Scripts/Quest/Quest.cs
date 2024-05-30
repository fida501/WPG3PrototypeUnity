using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    
    public string questName;
    
    public bool isQuestToCollectItem;
    public bool isQuestToKillEnemy;
    
    
    //Kill Enemy
    public float enemyToKill;

    //Collect Item
    public float itemToCollect;
    
    public bool isCompleted;
}
