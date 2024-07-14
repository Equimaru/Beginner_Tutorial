using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Catch
{
    public class InGameMenuManager : MonoBehaviour
    {
        public Action OnRestartRequest;
        public Action OnShopVisitRequest;
        public Action OnNextLevelEnterRequest;
        public Action OnMenuExitRequest;

        [SerializeField] private GameObject inGameMenuPanel;
        
        [SerializeField] private TextMeshProUGUI moneyAmountText;
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button shopButton;

        public void SetMoneyAmount(int moneyAmount)
        {
            moneyAmountText.text = "You  have " + moneyAmount;
        }

        public void Show(LevelStateType currentLevelStateType)
        {
            switch (currentLevelStateType)
            {
                case LevelStateType.InProgress:
                    nextLevelButton.interactable = false;
                    shopButton.interactable = false;
                    break;
                case LevelStateType.Cleared:
                    nextLevelButton.interactable = true;
                    shopButton.interactable = true;
                    break;
                case LevelStateType.Failed:
                    nextLevelButton.interactable = false;
                    shopButton.interactable = true;
                    break;
                default:
                    Debug.Log("Unknown type of level state.");
                    break;
            }
            
            inGameMenuPanel.SetActive(true);
        }

        public void Hide()
        {
            inGameMenuPanel.SetActive(false);
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

