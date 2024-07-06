using System;
using UnityEngine;
using Zenject;

namespace Catch
{
    public class ScoreSystem : MonoBehaviour
    {
        [Inject] private FillUpSystemUI _fillUpSystemUI;
        
        public Action OnLevelCleared;
        public Action OnLevelFailed;
    
        private int _currentCatchFoodCount,
             _goodItemToCatch;

        private float _percentageOfCatchFood,
            _minimalPercentageOfCatchFood;

        public float PercentageOfCatchFood => _percentageOfCatchFood;

        public void SetParameters(int eatableToCatch, float minimalPercentageOfCatchFood)
        {
            _minimalPercentageOfCatchFood = minimalPercentageOfCatchFood;
            _fillUpSystemUI.SetUpMinFillUpMarker(_minimalPercentageOfCatchFood);
            _goodItemToCatch = eatableToCatch;
            _currentCatchFoodCount = 0;
            FindPercentOfCatchFood();
            _fillUpSystemUI.SetCurrentFillUpMarker(PercentageOfCatchFood);
        }
    
        public void OnGoodItemCatch()
        {
            _currentCatchFoodCount++;
            FindPercentOfCatchFood();
        }

        public void OnGoodItemDrop()
        {
            FindPercentOfCatchFood();
        }

        private void FindPercentOfCatchFood()
        {
            _percentageOfCatchFood = (float)_currentCatchFoodCount / _goodItemToCatch;
            _fillUpSystemUI.SetCurrentFillUpMarker(_percentageOfCatchFood);
        }

        private bool CalcIfPassMinScore()
        {
            return _percentageOfCatchFood >= _minimalPercentageOfCatchFood;
        }

        public void ShowLevelResults()
        {
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

