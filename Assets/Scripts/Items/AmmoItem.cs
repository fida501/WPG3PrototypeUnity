using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    public Item item;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.IncreasePlayerAmmo(item.itemCount);
            Destroy(gameObject);
        }
    }
}