using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Update()
    {
        if (DialogueManager.GetInstance().IsDialogueIsPlaying == false)
        {
            SceneManager.LoadScene("1-1");
        }
    }
}
