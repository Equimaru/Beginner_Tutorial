using System;
using UnityEngine;

namespace Catch
{
    public class Garbage : ObjectToCatch
    {
        public void Start()
        {
            Rotate();
        }

        private void ReactToPlayerCatch()
        {
            OnBadCatchOrLost?.Invoke();
        }

        private void ReactToGatekeeperCatch()
        {
            
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