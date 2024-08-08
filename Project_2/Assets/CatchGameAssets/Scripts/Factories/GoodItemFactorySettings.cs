using System.Collections.Generic;
using UnityEngine;

public class GoodItemFactorySettings
{
    public List<GameObject> goodItemPrefabs;

    public GoodItemFactorySettings(List<GameObject> goodItemPrefabs)
    {
        this.goodItemPrefabs = goodItemPrefabs;
    }
}
