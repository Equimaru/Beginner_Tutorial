using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Catch
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

        private Rigidbody _rb;
        private Transform _transform;
    
        private float _playerSpeed;
        private float _inputAxis;

        public bool gameOver;

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
            if (!gameOver)
            {
                _rb.velocity = new Vector3(_inputAxis * _playerSpeed, 0, 0);
            }
        }
    }
}

