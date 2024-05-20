using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrAndBullets : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletStartPos;
    
    private Rigidbody _rb;

    private float _inputX,
        _inputY;

    private bool _jump,
        _shoot;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float bulletSpeed;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _shoot = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_inputX * playerSpeed, _rb.velocity.y, _inputY * playerSpeed);
        
        if (_jump)
        {
            Jump();
            _jump = false;
        }

        if (_shoot)
        {
            Shoot();
            _shoot = false;
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Shoot()
    {
        GameObject spawnedBullet = Instantiate(bullet, bulletStartPos.position, bullet.transform.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);
    }
}
