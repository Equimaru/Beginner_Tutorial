using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Catch
{
    public class InGameMenuManager
    {
        public Action OnRestartRequest;
        public Action OnShopVisitRequest;
        public Action OnNextLevelEnterRequest;
        public Action OnMenuExitRequest;

        [Inject] private GameObject _inGameMenuPanel;
        
        [Inject] private TextMeshProUGUI _moneyAmountText;
        
        [Inject] private Button _nextLevelButton;
        [Inject] private Button _retryButton;
        [Inject] private Button _menuButton;
        [Inject] private Button _shopButton;

        public void InitButtons()
        {
            _retryButton.onClick.AddListener(RequestRestart);
            _nextLevelButton.onClick.AddListener(RequestNextLevelEnter);
            _menuButton.onClick.AddListener(RequestMenuExit);
            _shopButton.onClick.AddListener(RequestShopVisit);
        }
        
        public void SetMoneyAmount(int moneyAmount)
        {
            _moneyAmountText.text = "You  have " + moneyAmount;
        }

        public void Show(LevelStateType currentLevelStateType)
        {
            switch (currentLevelStateType)
            {
                case LevelStateType.InProgress:
                    _nextLevelButton.interactable = false;
                    _shopButton.interactable = false;
                    break;
                case LevelStateType.Cleared:
                    _nextLevelButton.interactable = true;
                    _shopButton.interactable = true;
                    break;
                case LevelStateType.Failed:
                    _nextLevelButton.interactable = false;
                    _shopButton.interactable = true;
                    break;
                default:
                    Debug.Log("Unknown type of level state.");
                    break;
            }
            
            _inGameMenuPanel.SetActive(true);
        }

        public void Hide()
        {
            _inGameMenuPanel.SetActive(false);
        }
        
        public void RequestRestart()
        {
            OnRestartRequest?.Invoke();
        }

        public void RequestShopVisit()
        {
            OnShopVisitRequest?.Invoke();
        }

        public void RequestNextLevelEnter()
        {
            OnNextLevelEnterRequest?.Invoke();
        }

        public void RequestMenuExit()
        {
            OnMenuExitRequest?.Invoke();
        }
    }
}

