using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    private Rigidbody _rb;
    
    private float _playerSpeed;
    private float _inputAxis;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Init(PlayerInputActions playerInputActions, float playerSpeed)
    {
        _playerInputActions = playerInputActions;
        _playerSpeed = playerSpeed;
    }

    private void Update()
    {
        _inputAxis = _playerInputActions.Player.Movement.ReadValue<float>();
        Debug.Log(_inputAxis);
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector3(_inputAxis * _playerSpeed * Time.fixedDeltaTime, 0, 0), Space.Self);
    }
}
