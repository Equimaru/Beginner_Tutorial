using System.Collections.Generic;
using Catch;
using UnityEngine;

public class UneatableFactory : DroppableFactory
{
    [SerializeField] private List<GameObject> uneatablePrefabs;
        
    public override Droppable CreateDroppable()
    {
        int prefabInUse = Random.Range(0, uneatablePrefabs.Count);
        Vector3 pos = transform.position;
        GameObject newObject = Instantiate(uneatablePrefabs[prefabInUse], new Vector3(GetRandomXPos(), pos.y, pos.z), Quaternion.identity);
        return newObject.GetComponent<Droppable>();
    }
}
