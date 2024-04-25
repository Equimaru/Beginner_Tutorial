using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShakeViaDOTween : MonoBehaviour
{
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeStrenght;
    [SerializeField] private int vibrato;

    private Vector3 _originalPos;
    void Start()
    {
        _originalPos = transform.position;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.DOShakePosition(shakeDuration, new Vector3(shakeStrenght, shakeStrenght, 0), vibrato);
            transform.position = _originalPos;
        }
    }
}
