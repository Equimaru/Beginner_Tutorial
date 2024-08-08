using UnityEngine;
using Zenject;

namespace Catch
{
    public class GoodItemFactory : FallingItemFactory, IFactory<UnityEngine.Object, GoodItem>
    {
        private GoodItemFactorySettings _goodItemFactorySettings;
        
        private DiContainer _container;

        public GoodItemFactory(DiContainer container, GoodItemFactorySettings goodItemFactorySettings)
        {
            _container = container;
            _goodItemFactorySettings = goodItemFactorySettings;
        }
        
        public GoodItem Create(UnityEngine.Object prefab)
        {
            float defaultSpawnHeight = 7f;
            
            var newItem = _container.InstantiatePrefabForComponent<GoodItem>(prefab);
            newItem.gameObject.transform.position = new Vector3(GetRandomXPos(), defaultSpawnHeight, 0);
            return newItem;
        }
    }
}

