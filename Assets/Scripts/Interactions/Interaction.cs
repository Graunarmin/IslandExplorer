using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    protected Prerequisite[] prerequisites;
    protected Sprite icon;
    private bool _subscribedToInteractEvent;

    protected virtual void Awake()
    {
        this.enabled = false;
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void OnEnable()
    {
        GameManager.InteractionPressedEvent += TryInteracting;
        _subscribedToInteractEvent = true;
        prerequisites = gameObject.GetComponents<Prerequisite>();
        if (gameObject.GetComponent<Item>() != null)
        {
            icon = gameObject.GetComponent<Item>().itemInfo.icon;
        }
    }

    protected virtual void OnDisable()
    {
        if (_subscribedToInteractEvent)
        {
            GameManager.InteractionPressedEvent -= TryInteracting;
            _subscribedToInteractEvent = false;
        }
    }

    private void TryInteracting()
    {
        if (!AllPrerequisitesComplete())
        {
            GetFirstIncompletePrerequisite().ShowRequirements(icon);
            Interactable.ActiveInteractable.WasVisited();
        }
        else
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
        //Nothing to do here yet
    }

    protected void OnInteract()
    {
        Interactable.ActiveInteractable.WasInteractedWith(this);
        ReactToInteraction();
    }
    
    protected virtual void ReactToInteraction()
    {
        //Nothing to do here
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

    private Prerequisite GetFirstIncompletePrerequisite()
    {
        if (prerequisites.Length == 0)
        {
            return null;
        }

        foreach (Prerequisite pre in prerequisites)
        {
            if (!pre.Complete)
            {
                return pre;
            }
        }
        return null;
    }
}
