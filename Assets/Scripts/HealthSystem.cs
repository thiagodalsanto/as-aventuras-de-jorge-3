using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class HealthSystem : MonoBehaviour
{
    public ProgressBar progressBar;
    public bool dead;

    public Canvas deathCanvas;
    private bool isMouseLocked = true;


    public GameObject targetGameObject;
    public Component componentToDisable;

    private bool inContactWithDino;
    private float dinoContactTime = 1f;
    private float dinoContactTimer;
    public int damage = 2;

    void Start()
    {
        deathCanvas.enabled = false;

    }

    void Update()
    {
        if (dead == true)
        {
            PlayerDied();
        }

        if (inContactWithDino)
        {
            dinoContactTimer += Time.deltaTime;
            if (dinoContactTimer >= dinoContactTime)
            {
                TakeDamage(damage);
                dinoContactTimer = 0f;
            }
        }
        else
        {
            dinoContactTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dino"))
        {
            inContactWithDino = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dino"))
        {
            inContactWithDino = false;
        }
    }

    public void TakeDamage(int d) 
    {
        if (progressBar.currentValue >= 1)
        {
            progressBar.currentValue -= d;

            if (progressBar.currentValue == 0 || progressBar.currentValue < 0)
            {
                dead = true;
            }
        }
    }

    public void PlayerDied()
    {
        CinemachineBrain cinemachineBrain = targetGameObject.GetComponent<CinemachineBrain>();
        Behaviour componentBehaviour = componentToDisable as Behaviour;
        Time.timeScale = 0f;
        deathCanvas.enabled = true;

        componentBehaviour.enabled = false;
        cinemachineBrain.enabled = false;


        isMouseLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        dead = false;
        Time.timeScale = 1f;
        deathCanvas.enabled = false;

        isMouseLocked = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
