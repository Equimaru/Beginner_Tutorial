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
    }
}