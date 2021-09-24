using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkiTalki : MonoBehaviour
{
    [SerializeField] private Character owner;

    public static event Action<bool> WalkiTalkiCallEvent;
    private void OnEnable()
    {
        Quest.CompletedQuestEvent += Call;
    }

    private void OnDisable()
    {
        Quest.CompletedQuestEvent -= Call;
    }

    private void Call(Quest quest)
    {
        WalkiTalkiCallEvent?.Invoke(true);
        DialogManager.dialogManager.ActivateDialog(owner);
    }
}
