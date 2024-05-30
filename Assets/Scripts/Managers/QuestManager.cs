using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private PlayManager playManager;
    [SerializeField] private Player player;


    private void Start()
    {
        if (quest != null)
        {
            Debug.Log("The value of this enemy to kill is " + quest.enemyToKill);
            quest.isCompleted = false;
        }
    }

    private void Update()
    {
        if (quest != null)
        {
            if (quest.isQuestToCollectItem)
            {
                Debug.Log(" the value of this are " + player.GetPlayerBadges() + " and " + quest.itemToCollect);
                if (player.GetPlayerBadges() >= quest.itemToCollect)
                {
                    //quest.isCompleted = true;
                }
            }
            else if (quest.isQuestToKillEnemy)
            {
                Debug.Log(" the value of this are " + player.GetPlayerKills() + " and " + quest.enemyToKill);
                if (player.GetPlayerKills() >= quest.enemyToKill)
                {
                    quest.isCompleted = true;
                }
            }

            if (quest.isCompleted)
            {
                playManager.currentCondition = "Win";
            }
        }
    }
}