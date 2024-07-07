using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Catch
{
    public class AdManager : MonoBehaviour
    {
        public Action OnAdWatched;
        
        [SerializeField] private GameObject adOfferPanel;
        [SerializeField] private GameObject adConsumePanel;
        [SerializeField] private Image adTimer;

        [Inject] private LevelPlayAdsManager _levelPlayAdsManager;

        private void Start()
        {
            _levelPlayAdsManager.OnRewardedVideoWatched += OnRewardedVideoWatched;
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

        public async void AcceptAdOffer()
        {
            adOfferPanel.SetActive(false);
#if UNITY_ANDROID && !UNITY_EDITOR
            var result = await _levelPlayAdsManager.ShowRewardedVideo();
            // Handle result result -> add coins 
#elif UNITY_EDITOR
            ShowAd();
#endif
            
        }

        public void DeclineAdOffer()
        {
            adOfferPanel.SetActive(false);
        }

        private async void ShowAd()
        {
            adConsumePanel.SetActive(true);
            adTimer.DOFillAmount(1, 3f);
            await Task.Delay(3000);
            OnAdWatched?.Invoke();
            adConsumePanel.SetActive(false);
        }
    }
}