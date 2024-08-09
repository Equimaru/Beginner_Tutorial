using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ItemSystem
{
    public class ItemEntry
    {
        public string ID;
        public int Quantity;
    }

    public ItemSystem(List<InventoryItem> itemDB)
    {
        _availableItems = itemDB;
    }

    [Inject] private List<InventoryItem> _availableItems;
    
    private List<ItemEntry> _items;

    public void AddItemInInventory(string itemID, int count = 1)
    {
        var itemToStash = _items.FirstOrDefault(x => x.ID == itemID);
        if (itemToStash != null)
        {
            itemToStash.Quantity += count;
        }
        else
        {
            _items.Add(new ItemEntry
            {
                ID = itemID,
                Quantity = count
            });
        }
    }

    public bool TryUseItem(string itemID, int count)
    {
        var itemToUse = _items.FirstOrDefault(x => x.ID == itemID);
        if (itemToUse != null)
        {
            if (itemToUse.Quantity >= count)
            {
                itemToUse.Quantity -= count;
                return true;
            }
            else return false;
        }
        else return false;
    }

    public int GetItemQuantity(string itemID)
    {
        var itemToUse = _items.FirstOrDefault(x => x.ID == itemID);
        if (itemToUse != null)
        {
            return itemToUse.Quantity;
        }
        else
        {
            return 0;
        }
    }
    
    public void SaveInventory()
    {
        var saveInventoryJson = JsonUtility.ToJson(_items);
        PlayerPrefs.SetString("Inventory", saveInventoryJson);
    }

    public void LoadInventory()
    {
        var loadInventoryJson = PlayerPrefs.GetString("Inventory");
        _items = JsonUtility.FromJson<List<ItemEntry>>(loadInventoryJson);
    }
}
