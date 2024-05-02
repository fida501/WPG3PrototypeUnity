using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")] [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story _currentStory;
    private static DialogueManager instance;

    public bool IsDialogueIsPlaying { get; private set; }

    [SerializeField] private float typingSpeed = 1f;
    [SerializeField] private bool canContinueToNextLine = false;
    [SerializeField] private GameObject continueIcon;


    private Coroutine displayLineCoroutine;


    [Header("Tag Manager")] private const string SPEAKER_TAG = "speaker";
    [SerializeField] private TextMeshProUGUI speakerNameText;


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

        if (canContinueToNextLine && Input.GetKeyDown(KeyCode.Space))
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
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine = StartCoroutine(DisplayLine(_currentStory.Continue()));
//            dialogueText.text = _currentStory.Continue();
            HandleTags(_currentStory.currentTags);
        }
        else
        {
            //#TODO: Ubah ke StartCorountine dari tutorial
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.Log("Tag could not be appropriately parsed : " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    speakerNameText.text = tagValue;
                    break;
                default:
                    Debug.Log("Unrecognized tag : " + tagKey);
                    break;
            }
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        continueIcon.SetActive(false);
        canContinueToNextLine = false;
        bool isAddingRichTextTag = false;
        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogueText.text = line;
                break;
            }

            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        continueIcon.SetActive(true);
        canContinueToNextLine = true;
    }


    public delegate void DialogueTriggerHandler(TextAsset dialogueFile);

    public event DialogueTriggerHandler OnDialogueTriggere;

    public void TriggerDialogue(TextAsset dialogueFile)
    {
        OnDialogueTriggere?.Invoke(dialogueFile);
    }
}