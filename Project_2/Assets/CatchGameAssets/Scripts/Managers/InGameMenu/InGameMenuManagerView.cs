using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Catch
{
    public class InGameMenuManagerView : MonoBehaviour
    {
        public Action OnNextLevelButtonPressed;
        public Action OnRestartButtonPressed;
        public Action OnMenuButtonPressed;
        public Action OnShopButtonPressed;
        
        [Header("InGameMenuManager Attributes")]
        [SerializeField] private Button retryButton;
        [SerializeField] private Button menuButton;
        public Button nextLevelButton;
        public Button shopButton;

        private void Awake()
        {
            retryButton.onClick.AddListener(RestartButtonPressed);
            menuButton.onClick.AddListener(MenuButtonPressed);
            nextLevelButton.onClick.AddListener(NextLevelButtonPressed);
            shopButton.onClick.AddListener(ShopButtonPressed);
        }
        
        public GameObject inGameMenuPanel;
        
        public TextMeshProUGUI moneyAmountText;

        public void NextLevelButtonPressed()
        {
            OnNextLevelButtonPressed?.Invoke();
        }

        public void RestartButtonPressed()
        {
            OnRestartButtonPressed?.Invoke();
        }

        public void MenuButtonPressed()
        {
            OnMenuButtonPressed?.Invoke();
        }

        public void ShopButtonPressed()
        {
            OnShopButtonPressed?.Invoke();
        }
    }
}

