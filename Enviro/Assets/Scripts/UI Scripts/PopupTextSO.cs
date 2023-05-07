using UnityEngine;

[CreateAssetMenu(fileName = "PopupText", menuName = "ScriptableObjects/PopupText", order = 5)]
public class PopupTextSO : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] popupTexts;
}
