using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
