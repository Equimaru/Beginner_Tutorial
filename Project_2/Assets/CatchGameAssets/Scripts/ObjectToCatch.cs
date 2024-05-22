using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectToCatch : MonoBehaviour
{
    public static Action OnObjectCatch;
    public static Action OnObjectLost;
    
    private void Start()
    {
        transform.DORotate(new Vector3(360.0f, 360.0f, 360.0f), 5.0f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetRelative()
            .SetEase(Ease.Linear);
    }
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnObjectCatch?.Invoke();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Gatekeeper"))
        {
            OnObjectLost?.Invoke();
            Destroy(gameObject);
        }
    }
}
