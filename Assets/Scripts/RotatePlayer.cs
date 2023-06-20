using UnityEngine;
using Cinemachine;

public class RotatePlayer : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public GameObject rotatingObject;
    private bool rotatingLeft = false;
    private bool rotatingRight = false;
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotatingLeft = true;
            RotateCharacter(-90f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rotatingRight = true;
            RotateCharacter(90f);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rotatingLeft = false;
            ResetRotation();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rotatingRight = false;
            ResetRotation();
        }

        if (!rotatingLeft && !rotatingRight)
        {
            LookAtCamera();
        }
    }

    private void RotateCharacter(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + angle, 0f);
        if (!rotatingLeft && !rotatingRight)
        {
            rotatingObject.transform.rotation = Quaternion.Euler(rotatingObject.transform.rotation.eulerAngles.x, rotatingObject.transform.rotation.eulerAngles.y + angle, rotatingObject.transform.rotation.eulerAngles.z);
        }
    }

    private void ResetRotation()
    {
        if (!rotatingLeft && !rotatingRight)
        {
            transform.rotation = originalRotation;
            rotatingObject.transform.rotation = originalRotation;
        }
    }

    private void LookAtCamera()
    {
        Vector3 cameraPos = freeLookCamera.transform.position;
        Vector3 playerPos = transform.position;
        Vector3 direction = (playerPos - cameraPos).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(-direction, Vector3.up);
        targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y + 180, 0f);
        transform.rotation = targetRotation;
        rotatingObject.transform.rotation = targetRotation;
    }
}
