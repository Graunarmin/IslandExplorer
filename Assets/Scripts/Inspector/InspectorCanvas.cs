using System;
using UnityEngine;


public abstract class InspectorCanvas : MonoBehaviour
{
    protected void Start()
    {
        //gameObject.SetActive(false);
    }

    public virtual void Activate()
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
    
    
