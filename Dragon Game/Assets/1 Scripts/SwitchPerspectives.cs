using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPerspectives : MonoBehaviour
{
    public Camera cam;
    Vector3 cameraPosition;
    private float scale = 0.1f;

    void Update()
    {
        cameraPosition.y += Input.mouseScrollDelta.y * scale;
        cam.transform.position = cameraPosition;
    }
}
