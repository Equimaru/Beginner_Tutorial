using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Box : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float jumpForce;

    private bool _grounded = true;
    [SerializeField] private LayerMask ground;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpInTime());
    }

    private void Update()
    {
        _grounded = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, ground) == true;
    }

    private IEnumerator JumpInTime()
    {
        while (true)
        {
            if (_grounded)
            {
                Jump();
            }

            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}

