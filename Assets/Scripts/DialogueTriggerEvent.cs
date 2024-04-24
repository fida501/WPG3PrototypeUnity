using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerEvent : MonoBehaviour
{
    [SerializeField] private TextAsset dialogueFile;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //DialogueManager.GetInstance().StartDialogue(dialogueFile);
            DialogueManager.GetInstance().TriggerDialogue(dialogueFile);
            GetComponent<Collider>().enabled = false;
        }
    }
}
