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
         
        private float _jumpForce;
        
        [SerializeField] private float groundCheckDistance;
        [SerializeField] private LayerMask ground;
    
        private bool _jump;
        private bool _isGrounded;
        private bool _gameOver = false;
        
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        public void Init(InputActions inputActions, float jumpForce)
        {
            _inputActions = inputActions;
            _jumpForce = jumpForce;
            _inputActions.Player.Jump.performed += Jump;
        }
    
        private void Jump(InputAction.CallbackContext callbackContext)
        {
            if (_isGrounded && !_gameOver)
            {
                OnPlayerJump?.Invoke();
                _rb.velocity = Vector2.up * _jumpForce;
            }
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Obstacle"))
            {
                OnPlayerCrash?.Invoke();
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

