using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //DialogueTrigger Script using Inky
    [Header("Visual Cue")] 
    [SerializeField] private GameObject visualCue;

    [Header("Inky")] 
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
        playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Dialogue Triggered == " + inkJSON.text);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}