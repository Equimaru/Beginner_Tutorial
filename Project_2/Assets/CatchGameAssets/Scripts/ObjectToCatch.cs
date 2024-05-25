using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Catch
{
    public class ObjectToCatch : MonoBehaviour
    {
        public Action OnGoodCatch;
        public Action OnBadCatchOrLost;
        
        public void Rotate()
        {
            transform.DORotate(new Vector3(360.0f, 360.0f, 360.0f), 5.0f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetRelative()
                .SetEase(Ease.Linear);
        }
    }
}

