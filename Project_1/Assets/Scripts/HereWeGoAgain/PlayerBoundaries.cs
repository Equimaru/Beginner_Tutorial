using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    private Vector2 _screenBoundaries;
    private float _playerWidth;

    private void Start()
    {
        if (Camera.main != null)
            _screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Debug.Log(_screenBoundaries);
        _playerWidth = GameObject.Find("Car_Visuals").GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    private void LateUpdate()
    {
        ClampPlayerPos();
    }

    private void ClampPlayerPos()
    {
        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, _screenBoundaries.x * -1 + _playerWidth, _screenBoundaries.x - _playerWidth);
        transform.position = playerPos;
    }
}
