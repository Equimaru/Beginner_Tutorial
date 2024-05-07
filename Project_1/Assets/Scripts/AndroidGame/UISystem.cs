using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AndroidGame
{
    public class UISystem : MonoBehaviour
    {
        public Action OnRestartPressed;
    
        [SerializeField] private TextMeshProUGUI uWin;
        [SerializeField] private Button restart;

        public void ShowGameOverUI()
        {
            uWin.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }

        public void Restart()
        {
            OnRestartPressed?.Invoke();
        }
    }

}
