using System;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public Action OnFinishScoreReached;
    
    private int _score,
        _scoreToWin;

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

    public void DicreaseScore(int scoreLoss)
    {
        _score -= scoreLoss;
        _score = Math.Max(0, _score);
        scoreText.text = _score.ToString();
    }
}
