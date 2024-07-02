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

        private LevelPlayAdsManager _levelPlayAdsManager;

        private void Start()
        {
            _levelPlayAdsManager = LevelPlayAdsManager.Instance;
            
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

        public void AcceptAdOffer()
        {
            adOfferPanel.SetActive(false);
            
            IronSource.Agent.showRewardedVideo();
            //_levelPlayAdsManager.ShowRewardedVideo();
            //ShowAd();
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

