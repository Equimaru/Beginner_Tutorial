using System;
using System.Collections;
using System.Collections.Generic;
using Catch;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public Action OnNewRecordSet;
    
    private List<ObjectToCatch> _objectsList;
    
    private int _score,
        _recordScore;

    private bool _isRecordSet;

    public void Init()
    {
    }
    
    public void AddToObjList(ObjectToCatch obj)
    {
        _objectsList.Add(obj);
        obj.OnGoodCatch += IncrementScore;
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
