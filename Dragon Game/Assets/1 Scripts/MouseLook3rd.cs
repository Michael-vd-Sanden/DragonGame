using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook3rd : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;

    private float xRotation = 0f;
    private float yRotation = 0f;
    void Update()
    {
        if (Input.GetMouseButton(1)) 
        {   
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation -= mouseX;
            yRotation = Mathf.Clamp(90f, yRotation, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
