using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPrereq : Prerequisite
{
    public Tool requiredTool;

    public override bool Complete
    {
        get
        {
            if (Inventory.Instance.ContainsItem(requiredTool))
            {
                return true;
            }

            return false;
        }
    }

}
