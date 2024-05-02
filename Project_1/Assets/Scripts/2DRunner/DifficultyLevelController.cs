using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevelController : MonoBehaviour
{
    public static DifficultyLevelController Instance;

    [SerializeField] private float gameDifficultyModificator;
    [SerializeField] private float gameDifficultyCap;

    public int score;
    private float _gameSpeed;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IncreaseGameSpeed()
    {
        if (score <= gameDifficultyCap)
        {
            Time.timeScale = 1f + score / gameDifficultyModificator;
        }
    }
}
