using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Catch
{
    public class MenuController : MonoBehaviour
    {
        [Inject] private LevelPlayAdsManager _levelPlaysAdManger;
        
        private void Start()
        {
            _levelPlaysAdManger.LoadBanner();
        }
        public void Play()
        {
            SceneManager.LoadScene("CatchGame");
        }

        public void Exit()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            Application.Quit();
#elif UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}
