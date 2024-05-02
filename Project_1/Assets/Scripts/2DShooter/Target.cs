using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private GameManager _gameManager;
    
    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        Destroy(gameObject, 2f);
    }

}
