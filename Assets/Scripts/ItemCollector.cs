using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public bool haveHammer;
    public bool haveAxe;
    public bool havePickAxe;

    private void Start()
    {
        haveHammer = false;
        haveAxe = false;
        havePickAxe = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            CollectItem(other.gameObject.name);
        }
        
        if (other.CompareTag("Totem"))
        {
            Debug.Log(haveHammer);
            Debug.Log(haveAxe);
            Debug.Log(havePickAxe);
            if (haveHammer && haveAxe && havePickAxe )
            {
                LevelWinning();
            }
        }
    }

    private void CollectItem(string itemName)
    {
        if (itemName.Equals("Hammer"))
        {
            haveHammer = true;
        }
        else if (itemName.Equals("Axe"))
        {
            haveAxe = true;
        }
        else if (itemName.Equals("PickAxe"))
        {
            havePickAxe = true;
        }
    }

    private void LevelWinning()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Final");
    }
}
