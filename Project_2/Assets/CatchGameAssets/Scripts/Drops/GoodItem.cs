using UnityEngine;
using Zenject;

namespace Catch
{
    public class GoodItem : FallingItem
    {
        private Vector3 _startPos;
        
        public override ObjectType Type => ObjectType.Eatable;

        public void Awake()
        {
            transform.position = _startPos;
        }
        
        protected override void OnCatch()
        {
            OnCaught?.Invoke(this);
        }

        protected override void OnDrop()
        {
            OnDropped?.Invoke(this);
        }

        public class Factory : PlaceholderFactory<UnityEngine.Object, GoodItem>
        {
            
        }
    }
}