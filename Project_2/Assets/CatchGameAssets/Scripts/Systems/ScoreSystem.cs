using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Catch
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
    
        public Action OnLevelCleared;
        public Action OnLevelFailed;
    
        private int _currentCatchFoodCount,
             _maxFoodToCatch;

        private float _percentageOfCatchFood,
            _minimalPercentageOfCatchFood;

        public float PercentageOfCathcFood => _percentageOfCatchFood;

        public void SetParameters(float minimalPercentageOfCatchFood)
        {
            _minimalPercentageOfCatchFood = minimalPercentageOfCatchFood;
            _currentCatchFoodCount = 0;
            _maxFoodToCatch = 0;
        }
    
        public void SignUpForActions(Eatable eatable)
        {
        }
    
        public void OnFoodCatch()
        {
            _currentCatchFoodCount++;
            _maxFoodToCatch++;
            FindPercentOfCatchFood();
        }

        public void OnFoodDrop()
        {
            _maxFoodToCatch++;
            FindPercentOfCatchFood();
        }

        private void FindPercentOfCatchFood()
        {
            _percentageOfCatchFood = (float)_currentCatchFoodCount / _maxFoodToCatch;
            scoreText.text = _percentageOfCatchFood.ToString("0%") + " / " + _minimalPercentageOfCatchFood.ToString("0%");
        }

        private bool CalcIfPassMinScore()
        {
            return _percentageOfCatchFood >= _minimalPercentageOfCatchFood;
        }

        private bool ScanForCatchableObjectsOnScene()
        {
            return FindObjectOfType<Drop>();
        }

        public void StartSLRCoroutine()
        {
            StartCoroutine(ShowLevelResults());
        }
        
        private IEnumerator ShowLevelResults()
        {
            yield return new WaitUntil(() => ScanForCatchableObjectsOnScene() == false);
            if (CalcIfPassMinScore())
            {
                OnLevelCleared?.Invoke();
            }
            else
            {
                OnLevelFailed?.Invoke();
            }
        }
    }
}

