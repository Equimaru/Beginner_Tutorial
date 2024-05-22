using System;
using UnityEngine;

public class ObjectToCatch : MonoBehaviour
{
    public static Action OnObjectCatch;
    public static Action OnObjectLost;
    
    
    
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
