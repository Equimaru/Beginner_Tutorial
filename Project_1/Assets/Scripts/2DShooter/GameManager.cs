using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public GameObject winTitle;
    public GameObject target;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int _score = 0;
    private bool _win = false;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
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

    public void IncrementScore()
    {
        _score++;
        Debug.Log(_score);

        scoreText.text = _score.ToString();

        if (_score >= 10)
        {
            _win = true;
            
            winTitle.SetActive(true);
        }
    }
}
