using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Item
{
    [SerializeField] private bool disappearsOnCollect;
    [SerializeField] private bool isStackable;
}
