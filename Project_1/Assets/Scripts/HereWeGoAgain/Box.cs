using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float jumpForce;

    private bool _invokeInProgress = false;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_invokeInProgress)
        {
            float rndTime = Random.Range(2f, 5f);
            Invoke(nameof(Jump), rndTime);
            _invokeInProgress = true;
            Debug.Log("Jump!");
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _invokeInProgress = false;
    }
}
