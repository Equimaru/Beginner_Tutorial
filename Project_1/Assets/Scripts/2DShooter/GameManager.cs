using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    
    public GameObject winTitle;

    [SerializeField] private TextMeshProUGUI scoreText;
    private Camera _cam;

    private bool _win = false;
    
    private int _score = 0;
    public LayerMask droneLayer;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        _cam = Camera.main;
        
        TargetSpawner.Instance.StartSpawn();
    }

    public void GameOver()
    {
        TargetSpawner.Instance.StopSpawn();
        winTitle.SetActive(true);
        CursorManager.Instance.SetDefaultCursor();
    }

    private void IncrementScore()
    {
        _score++;
        Debug.Log(_score);

        scoreText.text = _score.ToString();

        if (_score < 10) return;

        _win = true;
        GameOver();
    }

    public void CheckForHit()
    {
        if (_win) return;
        
        RaycastHit2D hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero, droneLayer);

        if (hit.collider != null)
        {
            IncrementScore();
            AudioManager.Instance.PlayHitSound();
            GameObject drone = hit.collider.gameObject;
            Destroy(drone);
        }
        else
        {
            AudioManager.Instance.PlayMissSound();
        }
    }
}
