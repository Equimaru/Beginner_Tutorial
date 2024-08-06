using System;
using UnityEngine;
using Zenject;

namespace Catch
{
    public class InGameMenuManager: IInitializable
    {
        public Action OnRestartRequest;
        public Action OnShopVisitRequest;
        public Action OnNextLevelEnterRequest;
        public Action OnMenuExitRequest;
        public Action OnPauseResumeRequest;

        private InGameMenuManagerView _inGameMenuManagerView;

        public InGameMenuManager(InGameMenuManagerView inGameMenuManagerView)
        {
            _inGameMenuManagerView = inGameMenuManagerView;
        }

        public void Initialize()
        {
            _inGameMenuManagerView.OnMenuButtonPressed += RequestMenuExit;
            _inGameMenuManagerView.OnRestartButtonPressed += RequestRestart;
            _inGameMenuManagerView.OnShopButtonPressed += RequestShopVisit;
            _inGameMenuManagerView.OnNextLevelButtonPressed += RequestNextLevelEnter;
            _inGameMenuManagerView.OnPauseResumeButtonPressed += RequestPauseResume;
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

        public void RequestPauseResume()
        {
            Debug.Log("Hihihihi");
            OnPauseResumeRequest?.Invoke();
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

