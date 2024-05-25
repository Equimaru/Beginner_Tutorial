using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class StopParticleAnim : MonoBehaviour
    {
        [SerializeField] private float duration;
        
        void Start()
        {
            Destroy(this.gameObject, duration);
        }

    }

}
