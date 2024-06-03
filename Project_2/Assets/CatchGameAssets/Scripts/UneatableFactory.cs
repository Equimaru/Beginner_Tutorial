using System.Collections.Generic;
using Catch;
using UnityEngine;

public class UneatableFactory : DroppableFactory
{
    [SerializeField] private List<GameObject> uneatablePrefabs;
        
    public override Droppable CreateDroppable(Vector3 pos)
    {
        int prefabInUse = Random.Range(0, uneatablePrefabs.Count);
        GameObject newObject = Instantiate(uneatablePrefabs[prefabInUse], pos, Quaternion.identity);
        return newObject.GetComponent<Droppable>();
    }
}
