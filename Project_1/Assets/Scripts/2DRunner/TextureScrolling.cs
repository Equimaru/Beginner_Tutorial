using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrolling : MonoBehaviour
{
    private Material _material;

    public bool isScrolling = true;
    [SerializeField] private float scrollingSpeed;

    private Vector2 _offset;
    void Start()
    {
        _material = GetComponent<Renderer>().material;

        _offset = new Vector2(scrollingSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isScrolling)
        {
            _material.mainTextureOffset += _offset * Time.deltaTime;
        }
    }
}
