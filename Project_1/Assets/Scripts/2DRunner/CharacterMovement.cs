using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private InputActions _inputActions;
    [SerializeField] private Animator animator;

    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask ground;

    private bool _jump;
    private bool _isGrounded;
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
    }


    void Update() //Why not Fixed?
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, ground);

        if (GetJumpInput() && _isGrounded)
        {
            Jump();
        }
        
        animator.SetBool(IsGrounded, _isGrounded);
    }

    private void Jump()
    {
        //_isGrounded = false;
        
        _rb.velocity = Vector2.up * jumpForce;
        
        animator.SetTrigger(Jump1);
    }
    
    private bool GetJumpInput()
    {
        _inputActions.Player.Jump.performed += _ => _jump = true;
        bool jump = _jump;
        _jump = false;
        return jump;
    }

    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            animator.SetBool(IsGrounded, true);
        }
    }*/
}
