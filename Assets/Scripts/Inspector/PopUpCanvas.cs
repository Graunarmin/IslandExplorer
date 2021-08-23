using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PopUpCanvas : MonoBehaviour
{
    public Image interactButton;

    public float distanceToItem = 2f;

    public void Activate(Item item)
    {
        interactButton.transform.position = ComputePosition(item);
        Debug.Log("Position: " + interactButton.transform.position);
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private Vector3 ComputePosition(Item item)
    {
        Vector3 playerDirection = item.transform.position - References.instance.player.transform.position;
        Debug.Log("Player Direction: " + playerDirection);
        Vector3 destination = playerDirection * 2;
        Debug.Log("Destination: " + destination);
        return new Vector3(destination.x, destination.y, 10f);
        
    }
}
