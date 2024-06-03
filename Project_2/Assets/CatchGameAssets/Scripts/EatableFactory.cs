using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class EatableFactory : DroppableFactory
    {
        [SerializeField] private List<GameObject> eatablePrefabs;
        
        public override Droppable CreateDroppable(Vector3 pos)
        {
            int prefabInUse = Random.Range(0, eatablePrefabs.Count);
            GameObject newObject = Instantiate(eatablePrefabs[prefabInUse], pos, Quaternion.identity);
            return newObject.GetComponent<Droppable>();
        }
    }
}

