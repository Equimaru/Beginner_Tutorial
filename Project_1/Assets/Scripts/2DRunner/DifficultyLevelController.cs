using System;
using UnityEngine;

public class DifficultyLevelController : MonoBehaviour
{
    public static Action OnDifficultyIncrease;

    [SerializeField] private float gameDifficultyModificator;
    [SerializeField] private float gameDifficultyCap;

    public int score;
    private float _gameSpeed;

    public void IncreaseGameSpeed()
    {
        if (score <= gameDifficultyCap)
        {
            OnDifficultyIncrease?.Invoke();
        }
    }
}
