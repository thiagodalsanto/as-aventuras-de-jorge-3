using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    public bool dead;

    public Canvas deathCanvas;
    private bool isMouseLocked = true;

    private bool inContactWithDino;
    private float dinoContactTime = 1f;
    private float dinoContactTimer;

    void Start()
    {
        life = hearts.Length;
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
            TakeDamage(1);
        }

        if (inContactWithDino)
        {
            dinoContactTimer += Time.deltaTime;
            if (dinoContactTimer >= dinoContactTime)
            {
                TakeDamage(1);
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
        if (life >= 1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);

            if (life < 1)
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
