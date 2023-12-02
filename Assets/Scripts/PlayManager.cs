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

    [Header("Muzika")] public AudioSource audioSource;
    private int currentTrackIndex;
    public AudioClip[] musicTracks;


    private void Awake()
    {
        currentCondition = "Playing";
    }

    private void Start()
    {
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
        loseUI.SetActive(true);
    }

    public IEnumerator StartWinUI()
    {
        yield return new WaitForSeconds(2f);
        winUI.SetActive(true);
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