using UnityEngine;

namespace Catch
{
    public abstract class DroppableFactory : MonoBehaviour
    {
        public abstract Droppable CreateDroppable(Vector3 pos);
    }
}

