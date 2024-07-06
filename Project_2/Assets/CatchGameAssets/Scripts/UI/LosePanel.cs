using System;
using TMPro;
using UnityEngine;

namespace Catch
{
    public class LosePanel : MonoBehaviour
    {
        public Action OnRestartRequest;
        public Action OnShopVisitRequest;
        public Action OnMenuExitRequest;
        
        [SerializeField] private GameObject losePanel;

        [SerializeField] private TextMeshProUGUI moneyAmountText;

        public void SetMoneyAmount(int moneyAmount)
        {
            moneyAmountText.text = "You  have " + moneyAmount + " coins";
        }

        public void Show()
        {
            losePanel.SetActive(true);
        }

        public void Hide()
        {
            losePanel.SetActive(false);
        }
        
        public void RequestRestart()
        {
            OnRestartRequest?.Invoke();
        }

        public void RequestShopVisit()
        {
            OnShopVisitRequest?.Invoke();
        }

        public void RequestMenuExit()
        {
            OnMenuExitRequest?.Invoke();
        }
    }
}

