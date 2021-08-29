using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{   
    [HideInInspector] public Interactable interactable;


    private bool _subscribedToInteractEvent;

    protected virtual void Awake()
    {
        this.enabled = false;
        interactable = GetComponent<Interactable>();
    }

    protected virtual void OnEnable()
    {
        _subscribedToInteractEvent = true;
        GameManager.gameManager.InteractionEvent += Interact;
    }

    protected virtual void OnDisable()
    {
        if (_subscribedToInteractEvent)
        {
            GameManager.gameManager.InteractionEvent -= Interact;
        }
    }

    public virtual void Interact()
    {
        interactable.InteractionHappened();
    }

    
}
