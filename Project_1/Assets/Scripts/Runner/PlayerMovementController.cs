using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner
{
    public class PlayerMovementController : MonoBehaviour
    {
        public Action OnPlayerJump;
        public Action OnPlayerLand;
        public Action OnPlayerCrash;
        
        private Rigidbody2D _rb;
        private InputActions _inputActions;
        private RunnerParticleSystem _runnerParticleSystem;
         
        private float _jumpForce;
        
        private bool _jump;
        private bool _isGrounded;
        private bool _gameOver;
        
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        public void Init(InputActions inputActions, RunnerParticleSystem runnerParticleSystem, float jumpForce)
        {
            _inputActions = inputActions;
            _jumpForce = jumpForce;
            _inputActions.Player.Jump.performed += Jump;

            _runnerParticleSystem = runnerParticleSystem;
        }
    
        private void Jump(InputAction.CallbackContext callbackContext)
        {
            if (_isGrounded && !_gameOver)
            {
                OnPlayerJump?.Invoke();
                _rb.velocity = Vector2.up * _jumpForce;
            }
        }

        public void TurnOffMovement()
        {
            _gameOver = true;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Obstacle"))
            {
                OnPlayerCrash?.Invoke();
                Vector3 colPos = col.transform.position;
                _runnerParticleSystem.DoExplosion(colPos);
                Destroy(col.gameObject);
            }
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _isGrounded = true;
            OnPlayerLand?.Invoke();
        }
    
        private void OnCollisionExit2D(Collision2D other)
        {
            _isGrounded = false;
        }
    }
}

