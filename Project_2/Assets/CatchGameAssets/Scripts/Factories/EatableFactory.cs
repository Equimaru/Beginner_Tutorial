using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class EatableFactory : DroppableFactory
    {
        [SerializeField] private List<GameObject> eatablePrefabs;
        
        public override Droppable CreateDroppable()
        {
            int prefabInUse = Random.Range(0, eatablePrefabs.Count);
            Vector3 pos = transform.position;
            GameObject newObject = Instantiate(eatablePrefabs[prefabInUse], new Vector3(GetRandomXPos(), pos.y, pos.z), Quaternion.identity);
            return newObject.GetComponent<Droppable>();
        }
    }
}

