using System;
using System.Collections;
using UnityEngine;

namespace Catch
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private FillUpSystemUI fillUpSystemUI;
        
        public Action OnLevelCleared;
        public Action OnLevelFailed;
    
        private int _currentCatchFoodCount,
             _eatableToCatch;

        private float _percentageOfCatchFood,
            _minimalPercentageOfCatchFood;

        public float PercentageOfCatchFood => _percentageOfCatchFood;

        public void SetParameters(int eatableToCatch, float minimalPercentageOfCatchFood)
        {
            _minimalPercentageOfCatchFood = minimalPercentageOfCatchFood;
            fillUpSystemUI.SetUpMinFillUpMarker(_minimalPercentageOfCatchFood);
            _currentCatchFoodCount = 0;
            _eatableToCatch = eatableToCatch;
        }
    
        public void OnEatableCatch()
        {
            _currentCatchFoodCount++;
            FindPercentOfCatchFood();
        }

        public void OnEatableDrop()
        {
            FindPercentOfCatchFood();
        }

        private void FindPercentOfCatchFood()
        {
            _percentageOfCatchFood = (float)_currentCatchFoodCount / _eatableToCatch;
            fillUpSystemUI.SetCurrentFillUpMarker(_percentageOfCatchFood);
        }

        private bool CalcIfPassMinScore()
        {
            return _percentageOfCatchFood >= _minimalPercentageOfCatchFood;
        }

        private bool ScanForCatchableObjectsOnScene()
        {
            return FindObjectOfType<Droppable>();
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

