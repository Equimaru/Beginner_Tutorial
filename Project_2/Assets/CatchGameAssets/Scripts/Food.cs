using System;
using DG.Tweening;
using UnityEngine;

namespace Catch
{
    public class Food : ObjectToCatch
    {
        public void Start()
        {
            Rotate();
        }

        private void ReactToPlayerCatch()
        {
            OnGoodCatch?.Invoke();
        }

        private void ReactToGatekeeperCatch()
        {
            OnBadCatchOrLost?.Invoke();
        }
    
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ReactToPlayerCatch();
                Destroy(gameObject);
            }
            else if (other.CompareTag("Gatekeeper"))
            {
                ReactToGatekeeperCatch();
                Destroy(gameObject);
            }
        }
        
    }
}