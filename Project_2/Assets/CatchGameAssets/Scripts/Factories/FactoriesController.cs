
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Catch
{
    public class FactoriesController : IInitializable
    {
        private readonly GoodItemFactorySettings _goodItemFactorySettings;
        private readonly BadItemFactorySettings _badItemFactorySettings;
        private readonly GoodItem.Factory _goodItemFactory;
        private readonly BadItem.Factory _badItemFactory;

        private RandomGenerator _randomGenerator;

        private readonly float _goodItemDropChance = 0.5f;
        private readonly float _badItemDropChance = 0.5f;

        public FactoriesController(GoodItemFactorySettings goodItemFactorySettings, GoodItem.Factory goodItemFactory, BadItemFactorySettings badItemFactorySettings, BadItem.Factory badItemFactory)
        {
            _goodItemFactory = goodItemFactory;
            _goodItemFactorySettings = goodItemFactorySettings;
            _badItemFactory = badItemFactory;
            _badItemFactorySettings = badItemFactorySettings;
        }

        public FallingItem CreateFallingItem()
        {
            int factoryInUse = _randomGenerator.GetRandomResult();
            if (factoryInUse == 0)
            {
                int goodPrefabInUse = Random.Range(0, _goodItemFactorySettings.goodItemPrefabs.Count());
                var newGoodItem = _goodItemFactory.Create(_goodItemFactorySettings.goodItemPrefabs[goodPrefabInUse]);
                return newGoodItem;
            }
            int badPrefabInUse = Random.Range(0, _badItemFactorySettings.badItemPrefabs.Count());
            var newBadItem = _badItemFactory.Create(_badItemFactorySettings.badItemPrefabs[badPrefabInUse]);
            return newBadItem;
        }

        public void Initialize()
        {
            _randomGenerator = new RandomGenerator(new int[] {0, 1}, new float[] {_goodItemDropChance, _badItemDropChance});
        }
    }
}

