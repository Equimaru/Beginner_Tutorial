using System;
using TMPro;
using UnityEngine;

namespace Runner
{
    public class ScoreSystem : MonoBehaviour
    {
        public static ScoreSystem Instance;
        
        public Action OnRecordBreak;

        private UIManager _uIManager;

        private bool _recordIsBroken = false;
        public int currentRecord;
        
        private int _score;
        

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            
            if (PlayerPrefs.HasKey("maxScore"))
            {
                currentRecord = PlayerPrefs.GetInt("maxScore");
            }
        }
        
        public void Init(UIManager uIManager)
        {
            _uIManager = uIManager;
        }
        
        public void IncrementScore()
        {
            _score++;
            _uIManager.SetCurrentScore(_score);

            if (_score > currentRecord && !_recordIsBroken)
            {
                Debug.Log("Record is broken!");
                _recordIsBroken = true;
                OnRecordBreak?.Invoke();
            }

            if (_recordIsBroken)
            {
                currentRecord = _score;
            }
        }

        public void SetNewMaxScore()
        {
            if (_recordIsBroken)
            {
                PlayerPrefs.SetInt("maxScore", currentRecord);
            }
        }
    }
}

