using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private InputActions _gameInput;

    private void Start()
    {
        _gameInput = new InputActions();
        _gameInput?.Player.Enable();
        
        _gameInput.Player.Weapon.performed += i => GameManager.Instance.CheckForHit();
    }
}
