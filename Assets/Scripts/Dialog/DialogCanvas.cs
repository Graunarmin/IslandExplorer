using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogCanvas : InspectorCanvas
{
    [SerializeField] private Image speakerPortrait;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private TextMeshProUGUI dialogText;

    public void Activate(Sprite portrait, string spName, string diaText)
    {
        base.Activate();

        speakerPortrait.sprite = portrait;
        speakerName.text = spName;
        dialogText.text = diaText;
    }
    
}
