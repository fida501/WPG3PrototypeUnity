    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Ink.Runtime;
    using TMPro;
    using UnityEngine;

    public class DialogueManager : MonoBehaviour
    {
        [Header("Dialogue UI")]
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TextMeshProUGUI dialogueText;

        private Story _currentStory;
        private static DialogueManager instance;
        public bool IsDialogueIsPlaying { get; private set;}
        

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Found more than one instance of DialogueManager in the scene");
            }

            instance = this;
        }

        public static DialogueManager GetInstance()
        {
            return instance;
        }

        private void Start()
        {
            IsDialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
        }

        private void Update()
        {
            if (!IsDialogueIsPlaying)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ContinueDialogue();
            }
        }

        public void StartDialogue(TextAsset inkJSON)
        {
            _currentStory = new Story(inkJSON.text);
            IsDialogueIsPlaying = true;
            dialoguePanel.SetActive(true);
            ContinueDialogue();
        }

        private void ExitDialogueMode()
        {
            IsDialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
        }

        private void ContinueDialogue()
        {
            if (_currentStory.canContinue)
            {
                dialogueText.text = _currentStory.Continue();
            }
            else
            {
                ExitDialogueMode();
            }
        }
        
        
        public delegate void DialogueTriggerHandler(TextAsset dialogueFile);
        public event DialogueTriggerHandler OnDialogueTriggere;
        
        public void TriggerDialogue(TextAsset dialogueFile)
        {
            OnDialogueTriggere?.Invoke(dialogueFile);
        }
    }