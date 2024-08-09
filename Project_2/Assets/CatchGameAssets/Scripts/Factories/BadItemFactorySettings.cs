using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class BadItemFactorySettings
    {
        public readonly List<GameObject> badItemPrefabs;

        public BadItemFactorySettings(List<GameObject> badItemPrefabs)
        {
            this.badItemPrefabs = badItemPrefabs;
        }
    }
}

