using System;
using TMPro;
using UnityEngine;

namespace Catch
{
    public class UIManager : MonoBehaviour
    {
        public Action OnMenuExitRequest;
        public Action OnRestartRequest;
        public Action OnOpenShopRequest;
        public Action OnNextLevelRequest;
        
        
        [SerializeField] private TextMeshProUGUI moneyText;
        private int _money = 0;

        [SerializeField] private GameObject onWinPanel;
        [SerializeField] private GameObject onLosePanel;


        public void SetCurrentMoneyAmount(int currentMoney)
        {
            _money = currentMoney;
            moneyText.text = "You have " + _money + " coins";
        }
        
        public void ShowOnWinPanel()
        {
            onWinPanel.SetActive(true);
        }

        public void HideOnWinPanel()
        {
            onWinPanel.SetActive(false);
        }
        
        public void ShowOnLosePanel()
        {
            onLosePanel.SetActive(true);
        }

        public void HideOnLosePanel()
        {
            onLosePanel.SetActive(false);
        }

        public void RequestMenuExit()
        {
            OnMenuExitRequest?.Invoke();
        }

        public void RequestRestart()
        {
            OnRestartRequest?.Invoke();
        }

        public void RequestNextLevelEnter()
        {
            OnNextLevelRequest?.Invoke();
        }

        public void RequestToOpenShop()
        {
            OnOpenShopRequest?.Invoke();
        }
    }
}

