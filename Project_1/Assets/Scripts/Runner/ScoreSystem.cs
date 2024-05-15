using System;
using TMPro;
using UnityEngine;

namespace Runner
{
    public class ScoreSystem : MonoBehaviour
    {
        public Action OnRecordBreak;

        private UIManager _uIManager;

        private bool _recordBroken = false;
        private int _record;
        
        private int _score;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void Init(UIManager uIManager)
        {
            _uIManager = uIManager;
            _record = PlayerPrefs.GetInt("maxScore");
        }
        
        public void IncrementScore()
        {
            _score++;
            scoreText.text = "score: " + _score;
            _uIManager.GetCurrentScore(_score);

            if (_score > _record && !_recordBroken)
            {
                Debug.Log("Record is broken!");
                _recordBroken = true;
            }
        }
    }
}

