using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{   
    [HideInInspector] public Interactable interactable;
    public Prerequisite[] prerequisites;
    
    private bool _subscribedToInteractEvent;

    public event Action InteractionHappenedEvent;

    protected virtual void Awake()
    {
        this.enabled = false;
        interactable = GetComponent<Interactable>();
    }

    protected virtual void OnEnable()
    {
        GameManager.gameManager.InteractionEvent += Interact;
        _subscribedToInteractEvent = true;
        prerequisites = gameObject.GetComponents<Prerequisite>();
    }

    protected virtual void OnDisable()
    {
        if (_subscribedToInteractEvent)
        {
            GameManager.gameManager.InteractionEvent -= Interact;
            _subscribedToInteractEvent = false;
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interaction Happened");
        OnInteract();
    }

    protected void OnInteract()
    {
        // Tell the item that the Interaction is Complete
        // (non-static event that is subscribed to by item
        // so it does not need to hold a reference)
        InteractionHappenedEvent?.Invoke();
    }
    
    protected bool AllPrerequisitesComplete()
    {
        if (prerequisites.Length == 0)
        {
            return true;
        }

        foreach (Prerequisite pre in prerequisites)
        {
            if (!pre.Complete)
            {
                return false;
            }
        }
        return true;
    }
}
