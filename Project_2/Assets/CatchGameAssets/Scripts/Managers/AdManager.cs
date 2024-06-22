using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Catch
{
    public class AdManager : MonoBehaviour
    {
        public Action OnAdWatched;
        
        [SerializeField] private GameObject adOfferPanel;
        [SerializeField] private GameObject adConsumePanel;
        
        public void OpenAdOfferPanel()
        {
            adOfferPanel.SetActive(true);
        }

        public void AcceptAdOffer()
        {
            adOfferPanel.SetActive(false);
            
            ShowAd();
        }

        public void DeclineAdOffer()
        {
            adOfferPanel.SetActive(false);
        }

        private async void ShowAd()
        {
            adConsumePanel.SetActive(true);
            await Task.Delay(3000);
            OnAdWatched?.Invoke();
            adConsumePanel.SetActive(false);
        }
    }
}

