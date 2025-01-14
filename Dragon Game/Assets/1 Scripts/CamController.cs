using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{
    public Camera mainCam;
    public CinemachineVirtualCamera cam1stPerson;
    public CinemachineVirtualCamera cam3rdPerson;
    [SerializeField] MouseLook look1stPerson;
    [SerializeField] MouseLook3rd look3rdPerson;
    [SerializeField] float camZoomModifier = 0.1f;

    CinemachineVirtualCamera activeCam;
    CinemachineFramingTransposer framingTransposer3rdPerson;
    int activeCamPriorityModifyer = 100;
    float minZoomDistance = 1.75f;
    float maxZoomDistance = 10.0f;
    float scrollValue;

    private void Awake()
    {
        framingTransposer3rdPerson = cam3rdPerson.GetCinemachineComponent<CinemachineFramingTransposer>();
        activeCam = cam1stPerson;
    }

    private void Update()
    {
        scrollValue = Input.mouseScrollDelta.y;
        if(scrollValue != 0 ) 
        { 
            ZoomCamera();
        }
    }

    private void ZoomCamera() 
    {

        if (activeCam == cam3rdPerson) 
        {
            framingTransposer3rdPerson.m_CameraDistance = Mathf.Clamp
                (framingTransposer3rdPerson.m_CameraDistance + -scrollValue * camZoomModifier,
                minZoomDistance, maxZoomDistance);
            
            if (framingTransposer3rdPerson.m_CameraDistance == minZoomDistance)
            {
                ChangeCamera();
            }
        }
        else if (activeCam == cam1stPerson && scrollValue < 0)
        {
            ChangeCamera();
        }
    }

    private void ChangeCamera()
    {
        if (activeCam == cam3rdPerson) 
        {
            SetCamPriotity(cam3rdPerson, cam1stPerson);
            look1stPerson.enabled = true;
            look3rdPerson.enabled = false;
        }
        else
        {
            SetCamPriotity(cam1stPerson, cam3rdPerson);
            look1stPerson.enabled = false;
            look3rdPerson.enabled = true;
        }
    }

    private void SetCamPriotity(CinemachineVirtualCamera currentCam, CinemachineVirtualCamera newCam)
    {
        currentCam.Priority -= activeCamPriorityModifyer;
        newCam.Priority = activeCamPriorityModifyer;
        activeCam = newCam;
    }
}
