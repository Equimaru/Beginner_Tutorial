using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventoryItem")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] private string itemID;
    public string ItemID => itemID;
    
    [SerializeField] private string itemName;
    public string ItemName => itemName;
}
