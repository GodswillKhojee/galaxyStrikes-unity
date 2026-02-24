using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text ScoreBoard_text;

    public void increaseScore(int amount)
    {
        score += amount;
        Debug.Log(score); 
        ScoreBoard_text.text = score.ToString();
    }
}
