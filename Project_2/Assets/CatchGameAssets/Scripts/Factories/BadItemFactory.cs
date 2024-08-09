using UnityEngine;
using Zenject;

namespace Catch
{
    public class BadItemFactory : IFactory<Transform, Vector3, BadItem>
    {
        private readonly BadItemFactorySettings _badItemFactorySettings;
        
        private readonly DiContainer _container;

        public BadItemFactory(DiContainer container, BadItemFactorySettings badItemFactorySettings)
        {
            _container = container;
            _badItemFactorySettings = badItemFactorySettings;
        }
        
        public BadItem Create(Transform parentTransform, Vector3 pos)
        {
            int badItemPrefabInUse = Random.Range(0, _badItemFactorySettings.badItemPrefabs.Count);
            return _container.InstantiatePrefabForComponent<BadItem>(_badItemFactorySettings.badItemPrefabs[badItemPrefabInUse], pos, Quaternion.identity, parentTransform);
        }
    }
}
