using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    private Rigidbody _rb;
    private Transform _transform;
    
    private float _playerSpeed;
    private float _inputAxis;

    public void Init(PlayerInputActions playerInputActions, float playerSpeed)
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        
        _playerInputActions = playerInputActions;
        _playerSpeed = playerSpeed;
    }

    private void Update()
    {
        _inputAxis = _playerInputActions.Player.Movement.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        float leftBoarder = -9.5f,
            rightBoarder = 9.5f;
        gameObject.transform.Translate(new Vector3(_inputAxis * _playerSpeed * Time.fixedDeltaTime, 0, 0), Space.World);
        var position = _transform.position;
        position = new Vector3(Mathf.Clamp(position.x, leftBoarder, rightBoarder), position.y, 0);
        transform.position = position;
    }
}
