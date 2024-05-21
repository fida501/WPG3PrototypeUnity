using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    //create header named ui
    [Header("UI")] public Player player;
    public GameObject loseUI;
    public GameObject winUI;
    public string currentCondition;
    [SerializeField] private GameObject UIHUD;


    [Header("Muzika")] [SerializeField] public AudioSource audioSource;
    private int currentTrackIndex;
    public AudioClip[] musicTracks;


    [Header("Dialogue")] public DialogueTrigger dialogueTrigger;
    private TextAsset _endDialogue;

    private void Awake()
    {
        currentCondition = "Playing";
    }

    private void Start()
    {
        if (dialogueTrigger != null)
        {
            dialogueTrigger.DialogueTriggered();
        }

        PlayNextTrack();
    }

    private void Update()
    {
        if (currentCondition == "Lose")
        {
            StartCoroutine(StartLoseUI());
        }
        else if (currentCondition == "Win")
        {
            StartCoroutine(StartWinUI());
        }

        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    public IEnumerator StartLoseUI()
    {
        yield return new WaitForSeconds(2f);
        UIHUD.SetActive(false);
        loseUI.SetActive(true);
    }

    public IEnumerator StartWinUI()
    {
        yield return new WaitForSeconds(2f);
        UIHUD.SetActive(false);
        winUI.SetActive(true);
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(musicTracks[2]);
    }

    void PlayNextTrack()
    {
        
        // Play current sound
        // I would rather use PlayOneShot in order to allow multiple concurrent sounds
        audioSource.PlayOneShot(musicTracks[currentTrackIndex]);
        
        // Increase the index, wrap around if reached end of array
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        
    }
}