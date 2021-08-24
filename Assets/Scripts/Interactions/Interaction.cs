using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{   
    [HideInInspector] public Interactable interactable;


    private bool _subscribedToInteractEvent;

    private void Awake()
    {
        this.enabled = false;
        interactable = GetComponent<Interactable>();
    }

    private void OnEnable()
    {
        _subscribedToInteractEvent = true;
        GameManager.gameManager.InteractionEvent += Interact;
    }

    private void OnDisable()
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
