using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class TotemItems : MonoBehaviour
{
    public bool pickedItem1;
    public bool pickedItem2;
    public bool pickedItem3;

    public GameObject rejectedItem;

    public int winningItemCounter = 0;

    private bool isActiveRejectedItem = false;
    private float activeTimer = 0f;
    private float activeDuration = 2f;

    public ParticleSystem particleSystem;

    private void Start()
    {
        pickedItem1 = false;
        pickedItem2 = false;
        pickedItem3 = false;

        rejectedItem.SetActive(false);
    }

    private void Update()
    {

        if (isActiveRejectedItem)
        {
            activeTimer += Time.deltaTime;

            if (activeTimer >= activeDuration)
            {
                rejectedItem.SetActive(false);
                isActiveRejectedItem = false;
                activeTimer = 0f;
            }
        }

        if (pickedItem1 && pickedItem2 && pickedItem3)
        {
            LevelWinning();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (other.gameObject.name == "HammerV1(Clone)")
            {
                pickedItem1 = true;
                particleSystem.Play();
                Destroy(other.gameObject);
            } else if (other.gameObject.name == "AxeV1(Clone)")
            {
                pickedItem2 = true;
                particleSystem.Play();
                Destroy(other.gameObject);
            } else if (other.gameObject.name == "PickAxeV1(Clone)")
            {
                pickedItem3 = true;
                particleSystem.Play();
                Destroy(other.gameObject);
            }
            else
            {
                rejectedItem.SetActive(true);
                isActiveRejectedItem = true;
            }
        }
    }

    private void LevelWinning()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}