using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private bool startDialogueAvailable;
    [SerializeField] private DialogueTrigger dialogueTrigger;

    private void Start()
    {
        if (startDialogueAvailable)
        {
            dialogueTrigger.DialogueTriggered();
        }   
    }
}
