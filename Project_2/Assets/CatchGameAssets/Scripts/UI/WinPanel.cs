using System;
using TMPro;
using UnityEngine;

namespace Catch
{
    public class WinPanel : MonoBehaviour
    {
        public Action OnRestartRequest;
        public Action OnShopVisitRequest;
        public Action OnNextLevelEnterRequest;
        public Action OnMenuExitRequest;

        [SerializeField] private GameObject winPanel;
        
        [SerializeField] private TextMeshProUGUI moneyAmountText;

        public void SetMoneyAmount(int moneyAmount)
        {
            moneyAmountText.text = "You  have " + moneyAmount + " coins";
        }

        public void Show()
        {
            winPanel.SetActive(true);
        }

        public void Hide()
        {
            winPanel.SetActive(false);
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

