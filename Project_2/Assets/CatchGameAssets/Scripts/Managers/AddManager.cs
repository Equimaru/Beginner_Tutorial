using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Catch
{
    public class AddManager : MonoBehaviour
    {
        public Action OnAddWatched;
        
        [SerializeField] private GameObject addOfferPanel;
        [SerializeField] private GameObject addConsumePanel;
        
        public void OpenAddOfferPanel()
        {
            addOfferPanel.SetActive(true);
        }

        public void AcceptAddOffer()
        {
            addOfferPanel.SetActive(false);
            
            ShowAdd();
        }

        public void DeclineAddOffer()
        {
            addOfferPanel.SetActive(false);
        }

        private async void ShowAdd()
        {
            addConsumePanel.SetActive(true);
            await Task.Delay(3000);
            OnAddWatched?.Invoke();
            addConsumePanel.SetActive(false);
        }
    }
}

