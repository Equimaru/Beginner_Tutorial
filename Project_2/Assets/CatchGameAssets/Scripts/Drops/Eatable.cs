using System;
using DG.Tweening;
using UnityEngine;

namespace Catch
{
    public class Eatable : Drop
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