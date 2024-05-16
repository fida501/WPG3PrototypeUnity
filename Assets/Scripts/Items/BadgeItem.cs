using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeItem : MonoBehaviour
{
    public Item item;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.IncreasePlayerBadges(item.itemCount);
            Destroy(gameObject);
        }
    }
}
