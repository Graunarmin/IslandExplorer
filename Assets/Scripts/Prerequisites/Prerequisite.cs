using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerequisite : MonoBehaviour
{
    private bool itemAccess;
    public string requirements;

    public virtual bool Complete { get { return false; } }
    
    public void ShowRequirements()
    {
        Debug.Log(requirements);
    }
}
