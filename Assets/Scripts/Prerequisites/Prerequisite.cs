using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerequisite : MonoBehaviour
{
    private bool itemAccess;
    [SerializeField] string requirements;

    public virtual bool Complete { get { return false; } }
    
    public void ShowRequirements(Sprite icon)
    {
        if (!References.Instance.infoBoxCanvas.gameObject.activeInHierarchy)
        {
            References.Instance.infoBoxCanvas.Activate(icon, requirements);
        }
        else
        {
            References.Instance.infoBoxCanvas.Close();
        }
    }
}
