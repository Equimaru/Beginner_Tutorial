using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public static Action OnFinishScoreReached;
    
    private int _score;
    private int _scoreToWin;

    public void Init(int scoreToWin)
    {
        _scoreToWin = scoreToWin;
    }
    
    public void IncrementScore()
    {
        _score++;
        scoreText.text = _score.ToString();

        if (_score < _scoreToWin) return;
        
        OnFinishScoreReached?.Invoke();
    }
}
