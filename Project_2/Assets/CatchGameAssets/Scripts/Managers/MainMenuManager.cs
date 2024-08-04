using System;
using UnityEngine;
using Zenject;

namespace Catch
{
    public class MainMenuManager : IInitializable
    {
        public Action PlayRequest;
        public Action ShopVisitRequest;
        public Action ApplicationExitRequest;

        private MainMenuView _mainMenuView;
        private GameObject _menuPanel;

        [Inject]
        public void Inject(MainMenuView mainMenuView)
        {
            _mainMenuView = mainMenuView;
            _menuPanel = _mainMenuView.mainMenuPanel;
        }

        [Inject]
        public void Initialize()
        {
            _mainMenuView.OnPlayButtonPressed += RequestPlay;
            _mainMenuView.OnShopButtonPressed += RequestShopVisit;
            _mainMenuView.OnExitButtonPressed += RequestApplicationExit;
        }

        public void Show()
        {
            _menuPanel.SetActive(true);
            Debug.Log("Show");
        }

        public void Hide()
        {
            _menuPanel.SetActive(false);
            Debug.Log("Hide");
        }

        private void RequestPlay()
        {
            PlayRequest?.Invoke();
        }

        private void RequestShopVisit()
        {
            ShopVisitRequest?.Invoke();
        }

        private void RequestApplicationExit()
        {
            ApplicationExitRequest?.Invoke();
        }
    }
}

