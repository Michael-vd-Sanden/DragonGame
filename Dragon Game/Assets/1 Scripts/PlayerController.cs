using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isFlying;
    private bool allowedToFly;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "DragonRideable")
        { allowedToFly = true; }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "DragonRideable")
        { allowedToFly = false; }
    }

    private void toggleFlying()
    {
        
        
    }
}
