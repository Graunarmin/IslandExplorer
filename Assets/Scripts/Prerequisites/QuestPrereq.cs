using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPrereq : Prerequisite
{
    public Quest requiredQuest;

    public override bool Complete
    {
        get
        {
            return requiredQuest.IsActive();
        }
    }
}
