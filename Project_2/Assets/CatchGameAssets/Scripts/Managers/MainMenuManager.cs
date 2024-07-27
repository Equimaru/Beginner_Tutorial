using System;
using UnityEngine;
using Zenject;

namespace Catch
{
    public class MainMenuManager : IInitializable
    {
        public Action OnPlayRequest;
        public Action OnShopVisitRequest;
        public Action OnApplicationExitRequest;

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
            OnPlayRequest?.Invoke();
        }

        private void RequestShopVisit()
        {
            OnShopVisitRequest?.Invoke();
        }

        private void RequestApplicationExit()
        {
            OnApplicationExitRequest?.Invoke();
        }
    }
}

