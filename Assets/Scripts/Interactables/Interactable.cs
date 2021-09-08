using UnityEngine;
using System;


public abstract class Interactable : MonoBehaviour
{
    // !-Could lead to problems with overlapping Colliders-! 
    public static Interactable ActiveInteractable { get; private set; }
    
    [HideInInspector] public Collider col;
    public Interaction interaction;

    public static event Action<Interactable> InteractedEvent;

    void Awake()
    {
        if (GetComponent<Collider>() != null)
        {
            col = GetComponent<Collider>();
        }
        else
        {
            col = null;
        }
    }

    void SetActiveInteractable(bool set)
    {
        if (set)
        {
            ActiveInteractable = this;
        }
        else
        {
            ActiveInteractable = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interaction.enabled = true;
            SetActiveInteractable(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interaction.enabled = false;
            SetActiveInteractable(false);
        }
    }
    
    public virtual void WasInteractedWith()
    {
        // Broadcast that the Interaction on this Event is Complete so 
        // others (e.g. Quests) can respond accordingly
        InteractedEvent?.Invoke(this);
    }
}
