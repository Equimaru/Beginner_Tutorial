using Zenject;

namespace Catch
{
    public class BadItem : FallingItem
    {
        public override ObjectType Type => ObjectType.Uneatable;

        protected override void OnCatch()
        {
            OnCaught?.Invoke(this);
        }

        protected override void OnDrop()
        {
            OnDropped?.Invoke(this);
        }
        
        public class Factory : PlaceholderFactory<UnityEngine.Object, BadItem>
        {
            
        }
    }
}