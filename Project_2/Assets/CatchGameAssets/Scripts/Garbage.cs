using System;
using UnityEngine;

namespace Catch
{
    public class Garbage : ObjectToCatch
    {
        public Action OnCatchGarbage;
        public Action OnDropGarbage;
        
        public void Start()
        {
            Rotate();
        }

        public override void OnCatch()
        {
            OnCatchGarbage?.Invoke();
        }

        public override void OnDrop()
        {
            OnDropGarbage?.Invoke();
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