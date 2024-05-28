using System;
using DG.Tweening;
using UnityEngine;

namespace Catch
{
    public class Food : ObjectToCatch
    {
        public Action OnCatchFood;
        public Action OnDropFood;
        
        public void Start()
        {
            Rotate();
        }

        public override void OnCatch()
        {
            OnCatchFood?.Invoke();
        }

        public override void OnDrop()
        {
            OnDropFood?.Invoke();
        }
    
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnCatch();
                Destroy(gameObject);
            }
            else if (other.CompareTag("Gatekeeper"))
            {
                OnDrop();
                Destroy(gameObject);
            }
        }
        
    }
}