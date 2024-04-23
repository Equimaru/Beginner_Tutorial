using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    private Material _material;
    private Vector2 _offset;

    public float xVelocity;
    public float yVelocity;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material; //Try <Material>
    }

    private void Start()
    {
        _offset = new Vector2(xVelocity, yVelocity);
    }
    // Update is called once per frame
    private void Update()
    {
        _material.mainTextureOffset += _offset * Time.deltaTime;
    }
}
