using UnityEngine;


namespace Catch
{
    public class PlayerSaveSystem
    {
        public int CurrentLevel { get; private set; }
        public int MoneyAmount { get; private set; }
        public bool HasAmulet { get; private set; }


        public void Init(bool isCustomSettingsInUse, int customLevel, int customCurrency)
        {
            LoadCurrentLevel(isCustomSettingsInUse, customLevel);
            LoadMoneyAmount(isCustomSettingsInUse, customCurrency);
            LoadItemsFromStash();
        }

        public void OnMenuExit()
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
            MoneyAmount += moneyAmountToAdd;
        }

        public bool CheckForEnoughMoneyAmount(int moneyInNeed)
        {
            if (MoneyAmount >= moneyInNeed)
            {
                MoneyAmount -= moneyInNeed;
                return true;
            }
            
            Debug.Log("Not enough money!");
            return false;
        }

        public int GetMoneyAmount()
        {
            return MoneyAmount;
        }

        #endregion
        

        #region ItemsManaging
        
        public bool TryAddAmuletToPocket()
        {
            if (HasAmulet) return false;
            else
            {
                HasAmulet = true;
                return true;
            }
        }

        public bool TryUseAmuletFromPocket()
        {
            if (HasAmulet)
            {
                HasAmulet = false;
                return true;
            }
            else return false;
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

