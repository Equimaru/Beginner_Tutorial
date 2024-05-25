using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class Explosion : MonoBehaviour
    {
   
        void Start()
        {
            Destroy(this.gameObject, 2f);
        }

    }

}
