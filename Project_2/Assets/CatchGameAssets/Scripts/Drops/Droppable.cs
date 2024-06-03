using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Catch
{
    public abstract class Droppable : MonoBehaviour
    {
        public Action<Droppable> OnCaught;
        public Action<Droppable> OnDropped;

        public abstract ObjectType Type { get; }

        protected virtual void Start()
        {
            Rotate();
        }
        protected void Rotate()
        {
            transform.DORotate(new Vector3(360.0f, 360.0f, 360.0f), 5.0f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetRelative()
                .SetEase(Ease.Linear);
        }

        protected void OnTriggerEnter(Collider other)
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
        
        protected abstract void OnCatch();

        protected abstract void OnDrop();
    }
}

