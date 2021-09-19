using System;
using UnityEngine;


public abstract class InspectorCanvas : MonoBehaviour
{
    public static InspectorCanvas ActiveCanvas { get; private set; }

    public static event Action<bool> InteractingEvent;

    void SetActiveCanvas(bool set)
    {
        if (set)
        {
            ActiveCanvas = this;
        }
        else
        {
            ActiveCanvas = null;
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        CurrentlyInteracting(true);
        SetActiveCanvas(true);
    }
    
    public void Close()
    {
        gameObject.SetActive(false);
        CurrentlyInteracting(false);
        SetActiveCanvas(false);
    }
    
    public void CurrentlyInteracting(bool interacting)
    {
        InteractingEvent?.Invoke(interacting);
    }
}
    
    
