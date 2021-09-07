using UnityEngine;
using System;


public abstract class Interactable : MonoBehaviour
{
    public static Interactable ActiveInteractable { get; private set; }
    
    [HideInInspector] public Collider col;
    public Interaction interaction;

    public static event Action<Interactable> InteractedEvent;

    void Awake()
    {
        // Get the Collider Component
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

    private void OnEnable()
    {
        interaction.InteractionHappenedEvent += WasInteractedWith;
    }

    private void OnDisable()
    {
        interaction.InteractionHappenedEvent -= WasInteractedWith;
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
