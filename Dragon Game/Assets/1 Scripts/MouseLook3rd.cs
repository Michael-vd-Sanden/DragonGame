using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook3rd : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    public Transform camFollow;

    private float xRotation = 0f;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 60f);

        playerBody.Rotate(Vector3.up * mouseX);
        camFollow.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
