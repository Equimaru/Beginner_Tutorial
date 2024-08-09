using UnityEngine;


namespace Catch
{
    public class PlayerSaveSystem
    {
        public int CurrentLevel { get; private set; }
        public int MoneyAmount { get; private set; }
        public bool HasAmulet { get; private set; }
        
        private string _coinID = "coin";
        private string _amuletID = "amulet";

        private ItemSystem _itemSystem;

        public PlayerSaveSystem(ItemSystem itemSystem)
        {
            _itemSystem = itemSystem;
        }


        public void Init(bool isCustomSettingsInUse, int customLevel, int customCurrency)
        {
            LoadCurrentLevel(isCustomSettingsInUse, customLevel);
            LoadMoneyAmount(isCustomSettingsInUse, customCurrency);
            LoadItemsFromStash();
        }

        public void SaveParameters()
        {
            SaveCurrentLevel();
            SaveMoneyAmount();
            SaveItemsToStash();
        }

        #region LevelManaging

        public int GetCurrentLevel()
        {
            return CurrentLevel;
        }
        
        public void IncreaseCurrentLevel()
        {
            CurrentLevel++;
        }

        #endregion

        #region MoneyManaging

        public void AddMoneyAmount(int moneyAmountToAdd)
        {
            
            _itemSystem.AddItemInInventory(_coinID, moneyAmountToAdd);
        }

        public bool CheckForEnoughMoneyAmount(int moneyInNeed)
        {
            return _itemSystem.TryUseItem(_coinID, moneyInNeed);
        }

        public int GetMoneyAmount()
        {
            return _itemSystem.GetItemQuantity(_coinID);
        }

        #endregion
        

        #region ItemsManaging
        
        public bool TryAddAmuletToPocket()
        {
            if (_itemSystem.GetItemQuantity(_amuletID) < 1)
            {
                _itemSystem.AddItemInInventory(_amuletID);
                return true;
            }
            
            return false;
        }

        public bool TryUseAmuletFromPocket()
        {
            return _itemSystem.TryUseItem(_amuletID, 1);
        }
        
        #endregion
        

        #region PlayerPrefsLoading

        private void LoadCurrentLevel(bool isCustomSettingsInUse, int customLevel) // Is overload needed?
        {
            if (isCustomSettingsInUse)
            {
                CurrentLevel = customLevel;
            }
            else
            {
                CurrentLevel = PlayerPrefs.HasKey("currentLevel") ? PlayerPrefs.GetInt("currentLevel") : 1; //Check is 1 level first or 0 is one;
            }
        }

        private void LoadMoneyAmount(bool isCustomSettingsInUse, int customCurrency)
        {
            if (isCustomSettingsInUse)
            {
                MoneyAmount = customCurrency;
            }
            else
            {
                MoneyAmount = PlayerPrefs.HasKey("moneyAmount") ? PlayerPrefs.GetInt("moneyAmount") : 0;
            }
        }

        private void LoadItemsFromStash()
        {
            if (PlayerPrefs.HasKey("hasAmulet"))
            {
                HasAmulet = PlayerPrefs.GetInt("hasAmulet") == 1;
            }
        }

        #endregion

        #region PlayerPrefsSaving
        
        private void SaveCurrentLevel()
        {
            PlayerPrefs.SetInt("currentLevel", CurrentLevel);
        }

        private void SaveMoneyAmount()
        {
            PlayerPrefs.SetInt("moneyAmount", MoneyAmount);
        }

        private void SaveItemsToStash()
        {
            PlayerPrefs.SetInt("hasAmulet", HasAmulet ? 1 : 0);
        }

        #endregion
    }
}

