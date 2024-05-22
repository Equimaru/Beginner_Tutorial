using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public Action OnNewRecordSet;
    
    private int _score,
        _recordScore;

    private bool _isRecordSet;

    public void Init()
    {
        ObjectToCatch.OnObjectCatch += IncrementScore;
    }
    
    private void IncrementScore()
    {
        _score++;
        scoreText.text = "Score: " +_score;

        if (_score < _recordScore) return;
        
        SaveNewRecordScore();
        OnNewRecordSet?.Invoke();
    }

    private void SaveNewRecordScore()
    {
        
    }
}
