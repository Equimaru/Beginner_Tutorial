using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner
{
    public class CharacterMovementController : MonoBehaviour
    {
        public Action OnPlayerJump;
        public Action OnPlayerCrash;
        
        private Rigidbody2D _rb;
        private InputActions _inputActions;
        [SerializeField] private Animator animator;
    
        private float _jumpForce;
        [SerializeField] private float groundCheckDistance;
        [SerializeField] private LayerMask ground;
    
        private bool _jump;
        private bool _isGrounded;
        private bool _gameOver = false;
        private static readonly int Jump1 = Animator.StringToHash("Jump");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    
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
    
                animator.SetTrigger(Jump1);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Obstacle"))
            {
                OnPlayerCrash?.Invoke();
                Destroy(col.gameObject);
                animator.Play("Death");
                _gameOver = true;
                GameManager.Instance.EndPlayPhase();
            }
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _isGrounded = true;
            
            animator.SetBool(IsGrounded, _isGrounded);
        }
    
        private void OnCollisionExit2D(Collision2D other)
        {
            _isGrounded = false;
            
            animator.SetBool(IsGrounded, _isGrounded);
        }
    }
}

