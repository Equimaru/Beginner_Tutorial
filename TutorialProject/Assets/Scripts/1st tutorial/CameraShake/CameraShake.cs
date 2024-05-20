using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeTime;
    [SerializeField] private float shakeRange;

    private Transform _camTransform;

    private Vector3 _originalPos;

    void Start()
    {
        _camTransform = GetComponent<Transform>();
        _originalPos = _camTransform.position;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DoCameraShake());
        }
    }

    IEnumerator DoCameraShake()
    {
        float elapsedTime = 0;
        
        while (elapsedTime < shakeTime)
        {
            Vector3 pos = _originalPos + Random.insideUnitSphere * shakeRange;
            pos.z = _originalPos.z;

            elapsedTime += Time.deltaTime;

            _camTransform.position = pos;
                
            yield return null;
        }

        _camTransform.position = _originalPos;
    }
}
