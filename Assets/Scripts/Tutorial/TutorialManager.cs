using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialImageAD;
    public GameObject tutorialImageR;
    public GameObject tutorialImageMouse;
    public GameObject tutorialImageSpace;
    public int currentTutorialIndex = 0;
    public bool isTutorialDone = false;
    public PlayManager playManager;


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
            playManager.currentCondition = "Win";
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
}