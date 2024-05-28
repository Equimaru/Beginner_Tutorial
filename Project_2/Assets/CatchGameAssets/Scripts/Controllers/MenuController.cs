using System.Collections;
using System.Collections.Generic;
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
            if (Application.isEditor)
            {
                EditorApplication.isPlaying = false;
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
