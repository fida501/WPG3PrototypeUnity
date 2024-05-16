using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUIButtons : MonoBehaviour
{
    public string currentSceneName;

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

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}