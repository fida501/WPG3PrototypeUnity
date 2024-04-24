using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Inky")] [SerializeField] private TextAsset inkJSON;

    public void DialogueTriggered()
    {
        DialogueManager.GetInstance().StartDialogue(inkJSON);
    }
    
    public void SetTextAsset(TextAsset inkJson)
    {
        inkJSON = inkJson;
    }
}