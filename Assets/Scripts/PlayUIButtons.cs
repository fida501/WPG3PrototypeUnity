using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUIButtons : MonoBehaviour
{
    public string currentSceneName;

    [SerializeField] private string nextStageSceneName = "";


    //Button Function for lose Button Retry
    public void Retry()
    {
        currentSceneName = GetCurrentSceneName();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    private string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void NextStage()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextStageSceneName);
    }
}