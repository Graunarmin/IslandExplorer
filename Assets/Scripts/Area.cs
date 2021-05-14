    using System;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    [SerializeField]
    private Vector2 bottomLeft;
    
    [SerializeField]
    private Vector2 topRight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CameraController cam = References.instance.mainCamera.GetComponent<CameraController>();
            
        if (other.CompareTag(References.instance.player.tag))
        {
            cam.minPos = bottomLeft;
            cam.maxPos = topRight;
        }
    }
}
