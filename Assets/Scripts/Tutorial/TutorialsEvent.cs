using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialsEvent : MonoBehaviour
{
    TutorialManager tutorialManager;
    

    private void Start()
    {
        tutorialManager = TutorialManager.GetInstance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            if (tutorialManager.currentTutorialIndex == 0)
            {
                tutorialManager.tutorialImageAD.SetActive(true);
                tutorialManager.ExitTutorialAfter5Seconds();
                tutorialManager.currentTutorialIndex++;
            }
            else if (tutorialManager.currentTutorialIndex == 1)
            {
                tutorialManager.tutorialImageSpace.SetActive(true);
                tutorialManager.ExitTutorialAfter5Seconds();
                tutorialManager.currentTutorialIndex++;
            }
            else if (tutorialManager.currentTutorialIndex == 2)
            {
                tutorialManager.tutorialImageMouse.SetActive(true);
                tutorialManager.ExitTutorialAfter5Seconds();
                tutorialManager.currentTutorialIndex++;
            }
            else if (tutorialManager.currentTutorialIndex == 3)
            {
                tutorialManager.tutorialImageR.SetActive(true);
                tutorialManager.ExitTutorialAfter5Seconds();
                tutorialManager.currentTutorialIndex++;
            }
        }
    }
}