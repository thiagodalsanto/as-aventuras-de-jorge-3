using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public ProgressBar progressBar;
    public bool dead;

    public Canvas deathCanvas;
    private bool isMouseLocked = true;

    private bool inContactWithDino;
    private float dinoContactTime = 1f;
    private float dinoContactTimer;

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

        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(2);
        }

        if (inContactWithDino)
        {
            dinoContactTimer += Time.deltaTime;
            if (dinoContactTimer >= dinoContactTime)
            {
                TakeDamage(2);
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
            progressBar.currentValue -= 2;

            if (progressBar.currentValue == 0 || progressBar.currentValue < 0)
            {
                dead = true;
            }
        }
    }

    private void PlayerDied()
    {
        Time.timeScale = 0f;
        deathCanvas.enabled = true;

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
