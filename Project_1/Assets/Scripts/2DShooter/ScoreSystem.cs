using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public int score;
    public int scoreToWin;
    private bool _win = false;
    
    public void IncrementScore()
    {
        score++;
        Debug.Log(score);

        scoreText.text = score.ToString();

        if (score < scoreToWin) return;

        _win = true;
        GameManager.Instance.EndGame();
    }
}
