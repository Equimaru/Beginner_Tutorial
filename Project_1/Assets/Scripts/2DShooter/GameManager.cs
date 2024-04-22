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

    public GameObject winTitle;
    public GameObject target;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    private Camera _cam;

    private InputActions _gameInput;
    
    private int _score = 0;
    private bool _win = false;
    public LayerMask droneLayer;
    
    private void Start()
    {
        _gameInput = new InputActions();
        _gameInput?.Player.Enable();

        _cam = Camera.main;
        if (_cam != null)
        {
            Debug.Log(_cam.name);
        }

        InvokeRepeating(nameof(Spawn), 1f, 1f);

        _gameInput.Player.Weapon.performed += i => CheckForHit();
    }

    private void Update()
    {
        if (_win == true)
        {
            CancelInvoke(nameof(Spawn));
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, 4f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPosition, Quaternion.identity);
    }

    private void IncrementScore()
    {
        _score++;
        Debug.Log(_score);

        scoreText.text = _score.ToString();

        if (_score < 10) return;
        
        _win = true;
        winTitle.SetActive(true);
    }

    private void CheckForHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero, droneLayer);
        
        if(hit.collider != null)
        {
            IncrementScore();
            GameObject drone = hit.collider.gameObject;
            Destroy(drone);
        }
    }
}
