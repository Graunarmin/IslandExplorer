using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Follow: https://www.youtube.com/watch?v=4bLzrOMk2eY&t=608s
// Bounds: https://www.youtube.com/watch?v=kohwARSemR0
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.2f;
    
    //bottom left corner
    public Vector2 minPos;
    //top right corner
    public Vector2 maxPos;
    
    
    void LateUpdate()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        if (transform.position != target.position)
        {
            var position = transform.position;
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, position.z);
            
            // Set Camera Bounds between bottom left corner and top right corner
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y);
                
            position = Vector3.Lerp(position, targetPosition, smoothing);
            transform.position = position;
        }
    }
}
