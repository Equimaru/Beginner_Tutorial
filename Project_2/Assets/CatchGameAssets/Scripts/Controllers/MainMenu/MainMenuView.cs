using System;
using UnityEngine;
using UnityEngine.UI;

namespace Catch
{
    public class MainMenuView : MonoBehaviour
    {
        public Action OnPlayButtonPressed;
        public Action OnShopButtonPressed;
        public Action OnExitButtonPressed;

        [SerializeField] private Button playButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button exitButton;

        public GameObject mainMenuPanel;

        private void Start()
        {
            playButton.onClick.AddListener(PlayButtonPressed);
            shopButton.onClick.AddListener(ShopButtonPressed);
            exitButton.onClick.AddListener(ExitButtonPressed);
        }

        private void PlayButtonPressed()
        {
            OnPlayButtonPressed?.Invoke();
        }

        private void ShopButtonPressed()
        {
            OnShopButtonPressed?.Invoke();
        }

        private void ExitButtonPressed()
        {
            OnExitButtonPressed?.Invoke();
        }
    }
}

