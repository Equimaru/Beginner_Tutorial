using System;
using UnityEngine;

namespace Catch
{
    public class MainMenuManager : MonoBehaviour
    {
        public Action OnPlayRequest;
        public Action OnShopVisitRequest;
        public Action OnApplicationExitRequest;
        
        [SerializeField] private GameObject menuPanel;

        public void Show()
        {
            menuPanel.SetActive(true);
            Debug.Log("Show");
        }

        public void Hide()
        {
            menuPanel.SetActive(false);
            Debug.Log("Hide");
        }

        public void RequestPlay()
        {
            OnPlayRequest?.Invoke();
        }

        public void RequestShopVisit()
        {
            OnShopVisitRequest?.Invoke();
        }
        
        public void RequestApplicationExit()
        {
            OnApplicationExitRequest?.Invoke();
        }
    }
}

