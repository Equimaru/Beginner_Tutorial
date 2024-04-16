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

    public float speed = 5f;
    private Vector2 _inputVector;

    private int _score = 0;
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
        _rb.velocity = (Vector2.right * _inputVector.x).normalized * speed;
    }
    
    private void Update()
    {
        _inputVector = GetInputVectorNormalized();

        if (_inputVector.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (_inputVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    
    private Vector2 GetInputVectorNormalized()
    {
        Vector2 inputVector = _inputActions.Player.Movement.ReadValue<Vector2>();
        return inputVector = inputVector.normalized;
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
