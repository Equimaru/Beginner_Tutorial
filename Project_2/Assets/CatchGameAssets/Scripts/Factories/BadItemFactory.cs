using UnityEngine;
using Zenject;

namespace Catch
{
    public class BadItemFactory : FallingItemFactory, IFactory<UnityEngine.Object, BadItem>
    {
        private BadItemFactorySettings _badItemFactorySettings;
        
        private DiContainer _container;

        public BadItemFactory(DiContainer container, BadItemFactorySettings badItemFactorySettings)
        {
            _container = container;
            _badItemFactorySettings = badItemFactorySettings;
        }
        
        public BadItem Create(UnityEngine.Object prefab)
        {
            float defaultSpawnHeight = 7f;
            
            var newItem = _container.InstantiatePrefabForComponent<BadItem>(prefab);
            newItem.gameObject.transform.position = new Vector3(GetRandomXPos(), defaultSpawnHeight, 0);
            return newItem;
        }
    }
}
