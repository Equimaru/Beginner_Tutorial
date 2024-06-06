using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Runner
{
    public class ScoreSystem : MonoBehaviour
    {
        public static ScoreSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindExistingInstances() ?? CreateNewInstance();
                }

                return _instance;
            }
        }

        private static ScoreSystem _instance;
        
        public Action OnRecordBreak;

        private UIManager _uIManager;

        private bool _recordIsBroken;
        public int currentRecord;
        
        private int _score;
        
        private static ScoreSystem CreateNewInstance()
        {
            var gameObject = new GameObject("ScoreSystem");
            return gameObject.AddComponent<ScoreSystem>();
        }

        private static ScoreSystem FindExistingInstances()
        {
            ScoreSystem[] existingInstances = FindObjectsOfType<ScoreSystem>();

            if (existingInstances == null || existingInstances.Length == 0) return null;

            return existingInstances[0];
        }
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
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

