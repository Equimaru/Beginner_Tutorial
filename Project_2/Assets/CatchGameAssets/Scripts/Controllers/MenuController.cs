using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Catch
{
    public class MenuController : MonoBehaviour
    {

        public void Play()
        {
            SceneManager.LoadScene("CatchGame");
        }

        public void Exit()
        {
#if UNITY_ANDROID
            Application.Quit();
#elif UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}
