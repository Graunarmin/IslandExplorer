using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerequisite : MonoBehaviour
{
    private bool itemAccess;

    public virtual bool Complete { get { return false; } }
}
