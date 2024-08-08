using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class BadItemFactorySettings
    {
        public List<GameObject> badItemPrefabs;

        public BadItemFactorySettings(List<GameObject> badItemPrefabs)
        {
            this.badItemPrefabs = badItemPrefabs;
        }
    }
}

