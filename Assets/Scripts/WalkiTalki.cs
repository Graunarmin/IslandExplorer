using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkiTalki : MonoBehaviour
{
    [SerializeField] private Character owner;
    private void OnEnable()
    {
        Quest.CompletedQuestEvent += Call;
    }

    private void Call(Quest quest)
    {
        DialogManager.dialogManager.ActivateDialog(owner);
    }
}
