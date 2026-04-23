using TMPro;
using UnityEngine;

public class DialogLines : MonoBehaviour
{
    [SerializeField] string[] timeLineReference;
    [SerializeField] TMP_Text dialogText;

    int currentLine = 0;

    public void NextDialogueLine()
    {
        currentLine++;
        dialogText.text = timeLineReference[currentLine];
    }
}
