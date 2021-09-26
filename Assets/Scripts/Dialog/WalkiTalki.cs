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
        StartCoroutine(ShowDialog(1.5f));
    }

    IEnumerator ShowDialog(float waitTime)
    {
        yield return new WaitForSeconds(waitTime / 2f);
        WalkiTalkiCallEvent?.Invoke(true);
        yield return new WaitForSeconds(waitTime);
        DialogManager.dialogManager.ActivateDialog(owner);
        
    }
}
