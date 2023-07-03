using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject goBackMenu;


    public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void InfoButton() {
        goBackMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
