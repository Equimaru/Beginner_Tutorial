using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //So TextMeshPro doesn't need it?


public class MovementNew : MonoBehaviour
{
    private Rigidbody2D _rb;
    private InputActions _inputActions;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI scoreText;
    public Animator carAnimator;

    public float speed = 5f;
    private float _inputAxis;

    private bool _isWalking;

    private int _score = 0;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _inputActions = new InputActions();
        if (_inputActions != null)
        {
            _inputActions.Player.Enable();
        }
    }
    private void Start()
    {
        Debug.Log("To move use WASD(new Input System)");
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.right * _inputAxis * speed;
    }
    
    private void Update()
    {
        _inputAxis = GetAxisInputValueNormalized();

        if (_inputAxis > 0)
        {
            spriteRenderer.flipX = false;
            _isWalking = true;
        }
        else if (_inputAxis < 0)
        {
            spriteRenderer.flipX = true;
            _isWalking = true;
        }
        else
        {
            _isWalking = false;
        }
        
        carAnimator.SetBool(IsWalking, _isWalking);
    }
    
    private float GetAxisInputValueNormalized()
    {
        float value = _inputActions.Player.Movement.ReadValue<float>();
        return value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destructible"))
        {
            Destroy(collision.gameObject);
            _score++;

            scoreText.text = _score.ToString();

            if (_score >= 4)
            {
                Invoke(nameof(Restart), 3f);
            }
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("HereWeGoAgain");
    }
}
