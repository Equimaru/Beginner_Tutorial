using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Catch
{
    public class InMenuAdsManager : MonoBehaviour
    {
        public Action OnAdWatched;
        
        [SerializeField] private GameObject adOfferPanel;
        [SerializeField] private GameObject adConsumePanel;
        [SerializeField] private Image adTimer;
        
        [Inject] private LevelPlayAds _levelPlayAds;

        private bool _isNoAdsPurchased;

        private void Start()
        {
            _levelPlayAds.OnRewardedVideoWatched += OnRewardedVideoWatched;
        }

        private void OnRewardedVideoWatched(AdResultType obj)
        {
            if (obj == AdResultType.Successfully)
            {
                OnAdWatched?.Invoke();
            }
            else if (obj == AdResultType.Failed)
            {
                Debug.Log("RewardedVideo wasn't watched");
            }
        }

        public void OpenAdOfferPanel()
        {
            adOfferPanel.SetActive(true);
        }

        public void AcceptAdOffer()
        {
            adOfferPanel.SetActive(false);
            ShowAd();
        }

        private async void ShowAd()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            var result = await _levelPlayAdsManager.ShowRewardedVideo();
            // Handle result result -> add coins 
#elif UNITY_EDITOR
            adConsumePanel.SetActive(true);
            adTimer.DOFillAmount(1, 3f);
            await Task.Delay(3000);
            OnAdWatched?.Invoke();
            adConsumePanel.SetActive(false);
#endif
        }
        
        public void DeclineAdOffer()
        {
            adOfferPanel.SetActive(false);
        }
        
        public void ShowBanner()
        {
            _levelPlayAds.LoadBanner();
        }
    }
}
