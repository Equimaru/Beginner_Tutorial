using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class GoodItemFactoryOld : FallingItemFactoryOld
    {
        [SerializeField] private List<FallingItem> goodItemsPrefabs;
        
        public override FallingItem CreateFallingItem()
        {
            int prefabInUse = Random.Range(0, goodItemsPrefabs.Count);
            Vector3 pos = transform.position;
            var newItem = Instantiate(goodItemsPrefabs[prefabInUse], new Vector3(GetRandomXPos(), pos.y, pos.z), Quaternion.identity);
            return newItem;
        }
    }
}

