using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner
{
    public class CharacterMovementController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private InputActions _inputActions;
        [SerializeField] private Animator animator;
    
        [SerializeField] private float jumpForce;
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
    
            _inputActions = new InputActions();
        }
        
        void Start()
        {
            _inputActions.Player.Enable();
            _inputActions.Player.Jump.performed += Jump;
        }
    
    
    
        private void Jump(InputAction.CallbackContext callbackContext)
        {
            if (_isGrounded && !_gameOver)
            {
                _rb.velocity = Vector2.up * jumpForce;
    
                animator.SetTrigger(Jump1);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Obstacle"))
            {
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

