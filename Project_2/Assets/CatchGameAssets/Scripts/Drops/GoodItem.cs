using UnityEngine;
using Zenject;

namespace Catch
{
    public class GoodItem : FallingItem
    {
        public override ObjectType Type => ObjectType.Eatable;

        protected override void OnCatch()
        {
            OnCaught?.Invoke(this);
        }

        protected override void OnDrop()
        {
            OnDropped?.Invoke(this);
        }

        public class Factory : PlaceholderFactory<Transform, Vector3, GoodItem>
        {
            
        }
    }
}