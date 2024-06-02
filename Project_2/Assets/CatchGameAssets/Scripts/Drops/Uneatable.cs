using System;
using UnityEngine;

namespace Catch
{
    public class Uneatable : Drop
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
    }
}