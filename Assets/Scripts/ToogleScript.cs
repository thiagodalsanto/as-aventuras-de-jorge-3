using UnityEngine;

public class ToogleScript : MonoBehaviour
{
    public KeyCode toggleKey;
    public MonoBehaviour scriptToToggle;
    public float delayInSeconds = 2f;

    private bool toggleScheduled = false;
    private float toggleTime = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            toggleScheduled = true;
            toggleTime = Time.time + delayInSeconds;
        }

        if (toggleScheduled && Time.time >= toggleTime)
        {
            bool isScriptEnabled = scriptToToggle.enabled;
            scriptToToggle.enabled = !isScriptEnabled;
            toggleScheduled = false;
        }
    }
}
