using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToDestroy;

    public ProgressBar progressBar;

    public HealthSystem healthSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateObjects();
            DeactivateObjects();
        }
    }

    private void ActivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
            progressBar.currentValue = 4;
        }

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        healthSystem.damage = 1;
    }

    private void DeactivateObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }
}

