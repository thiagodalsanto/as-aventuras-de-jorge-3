using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;
    public KeyCode toggleKey = KeyCode.Space;

    private bool isObjectEnabled = true;

    private void Start()
    {
        objectToDisable.SetActive(isObjectEnabled);
        objectToEnable.SetActive(!isObjectEnabled);
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isObjectEnabled = !isObjectEnabled;

            objectToDisable.SetActive(isObjectEnabled);
            objectToEnable.SetActive(!isObjectEnabled);
        }
    }
}
