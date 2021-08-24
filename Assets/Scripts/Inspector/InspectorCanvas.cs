using System;
using UnityEngine;


public abstract class InspectorCanvas : MonoBehaviour
{
    protected void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        CurrentlyInteracting(true);
    }
    
    public void Close()
    {
        gameObject.SetActive(false);
        CurrentlyInteracting(false);
    }
    
    public virtual void CurrentlyInteracting(bool interacting)
    {
        if (interacting)
        {
            GameManager.gameManager.FreezeMovement();
        }
        else
        {
            GameManager.gameManager.UnfreezeMovement();
        }
    }
}
    
    
