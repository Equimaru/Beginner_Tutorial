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

        private InGameMenuManagerView _inGameMenuManagerView;
        
        [Inject]
        public void Inject(InGameMenuManagerView inGameMenuManagerView)
        {
            _inGameMenuManagerView = inGameMenuManagerView;
            inGameMenuManagerView.OnMenuButtonPressed += RequestMenuExit;
            inGameMenuManagerView.OnRestartButtonPressed += RequestRestart;
            inGameMenuManagerView.OnShopButtonPressed += RequestShopVisit;
            inGameMenuManagerView.OnNextLevelButtonPressed += RequestNextLevelEnter;
        }
        
        public void SetMoneyAmount(int moneyAmount)
        {
            _inGameMenuManagerView.moneyAmountText.text = "You  have " + moneyAmount;
        }

        public void Show(LevelStateType currentLevelStateType)
        {
            switch (currentLevelStateType)
            {
                case LevelStateType.InProgress:
                    _inGameMenuManagerView.nextLevelButton.interactable = false;
                    _inGameMenuManagerView.shopButton.interactable = false;
                    break;
                case LevelStateType.Cleared:
                    _inGameMenuManagerView.nextLevelButton.interactable = true;
                    _inGameMenuManagerView.shopButton.interactable = true;
                    break;
                case LevelStateType.Failed:
                    _inGameMenuManagerView.nextLevelButton.interactable = false;
                    _inGameMenuManagerView.shopButton.interactable = true;
                    break;
                default:
                    Debug.Log("Unknown type of level state.");
                    break;
            }
            
            _inGameMenuManagerView.inGameMenuPanel.SetActive(true);
        }

        public void Hide()
        {
            _inGameMenuManagerView.inGameMenuPanel.SetActive(false);
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

