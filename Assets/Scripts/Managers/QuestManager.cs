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
            quest.isCompleted = false;
        }
    }

    private void Update()
    {
        if (quest != null)
        {
            if (quest.isQuestToCollectItem)
            {
                if (player.GetPlayerBadges() >= quest.itemToCollect)
                {
                    quest.isCompleted = true;
                }
            } else if (quest.isQuestToKillEnemy)
            {
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
