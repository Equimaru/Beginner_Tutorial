using UnityEngine;
using static UnityEngine.Input;

public class MovementLegacy : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    private float _xInput,
        _yInput;

    public float speed = 5f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Debug.Log("To move use arrows or IJKL (Legacy Input System");
    }

    private void FixedUpdate()
    {
        _rb.velocity = (Vector2.right * _xInput).normalized * speed;
    }

    private void Update()
    {
        GetInputForLegacyMovement();
    }

    private void GetInputForLegacyMovement()
    {
        _xInput = GetAxis("Horizontal");
        _yInput = GetAxis("Vertical");
    }
}
