using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackMenu : MonoBehaviour
{

    public GameObject deactivateGoBack;
    public GameObject activateMainMenu;

    public void GoBack()
    {
        activateMainMenu.SetActive(true);
        deactivateGoBack.SetActive(false);
    }
}
