using System.Collections.Generic;
using System.Linq;
using Zenject;

public class ItemSystem
{
    [Inject] private List<InventoryItem> _availableItems;

    private List<InventoryItem> _inventory;

    public void AddItemInInventory(string itemID)
    {
        _inventory.Add(_availableItems.First(x => x.ItemID == itemID));
    }

    public bool TryUseItem(string itemID)
    {
        var checkingList = _inventory.Where(x => x.ItemID == itemID);
        
        if (checkingList.Any())
        {
            _inventory.Remove(_inventory[0]);
            return true;
        }

        return false;
    }
}
