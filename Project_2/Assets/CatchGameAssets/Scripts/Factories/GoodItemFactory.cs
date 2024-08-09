using UnityEngine;
using Zenject;

namespace Catch
{
    public class GoodItemFactory : IFactory<Transform, Vector3, GoodItem>
    {
        private readonly GoodItemFactorySettings _goodItemFactorySettings;
        
        private readonly DiContainer _container;

        public GoodItemFactory(DiContainer container, GoodItemFactorySettings goodItemFactorySettings)
        {
            _container = container;
            _goodItemFactorySettings = goodItemFactorySettings;
        }
        
        public GoodItem Create(Transform parentTransform, Vector3 pos)
        {
            int goodItemPrefabInUse = Random.Range(0, _goodItemFactorySettings.goodItemPrefabs.Count);
            return _container.InstantiatePrefabForComponent<GoodItem>(
                _goodItemFactorySettings.goodItemPrefabs[goodItemPrefabInUse], pos, Quaternion.identity,
                parentTransform);
        }
    }
}

