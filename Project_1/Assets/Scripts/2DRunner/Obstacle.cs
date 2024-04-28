using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    [SerializeField] private float movementSpeed;

    private float _destroyPosition = -15f;
    private float _scorePosition = -7.7f;

    private bool _scored = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x < _scorePosition && !_scored)
        {
            _scored = true;
            RunnerGameManager.Instance.IncrementScore();
        }
        
        if (transform.position.x < _destroyPosition)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.left * movementSpeed;
    }
}
