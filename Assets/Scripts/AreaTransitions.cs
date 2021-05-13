using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{

    private CameraController cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPos = newMinPos;
            cam.maxPos = newMaxPos;
        }
    }
}
