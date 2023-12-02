using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIButtons : MonoBehaviour
{
    //Button Function for lose Button Retry
    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}