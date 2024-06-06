using System.Collections.Generic;
using Catch;
using UnityEngine;

public class BadItemFactory : FallingItemFactory
{
    [SerializeField] private List<FallingItem> badItemsPrefabs;
        
    public override FallingItem CreateFallingItem()
    {
        int prefabInUse = Random.Range(0, badItemsPrefabs.Count);
        Vector3 pos = transform.position;
        var newItem = Instantiate(badItemsPrefabs[prefabInUse], new Vector3(GetRandomXPos(), pos.y, pos.z), Quaternion.identity);
        return newItem;
    }
}
