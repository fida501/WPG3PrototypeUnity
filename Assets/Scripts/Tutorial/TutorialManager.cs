using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialImageAD;
    public GameObject tutorialImageR;
    public GameObject tutorialImageMouse;
    public GameObject tutorialImageSpace;
    public int currentTutorialIndex = 0;
    public bool isTutorialDone = false;
    public PlayManager playManager;

    //TODO : cuma buat playtest, jangan lupa di hapus
    public string nextStageName = "1-1";


    private static TutorialManager instance;

    public static TutorialManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        tutorialImageAD.SetActive(false);
        tutorialImageR.SetActive(false);
        tutorialImageMouse.SetActive(false);
        tutorialImageSpace.SetActive(false);
    }

    private void Update()
    {
        if (currentTutorialIndex == 4)
        {
            isTutorialDone = true;
        }

        if (isTutorialDone)
        {
            ExitTutorialAfter5Seconds();
            //TODO: cuma buat playtest, nanti jangan lupa di ganti
//            playManager.currentCondition = "Win";
            // start ienumerator to start next stage after 5 seconds
            StartCoroutine(StartStage1After5Seconds());
        }
    }

    public void DIsableAllTutorials()
    {
        tutorialImageAD.SetActive(false);
        tutorialImageR.SetActive(false);
        tutorialImageMouse.SetActive(false);
        tutorialImageSpace.SetActive(false);
    }

    public void ExitTutorialAfter5Seconds()
    {
        StartCoroutine(ExitTutorial());
    }

    public IEnumerator ExitTutorial()
    {
        yield return new WaitForSeconds(2f);
        DIsableAllTutorials();
    }

    //TODO: Cuma buat playtest, jangan lupa di ganti
    //courutine, do StartStage1() after 5 seconds
    public IEnumerator StartStage1After5Seconds()
    {
        yield return new WaitForSeconds(5f);
        StartStage1();
    }

    public void StartStage1()
    {
        SceneManager.LoadScene(nextStageName);
    }
}