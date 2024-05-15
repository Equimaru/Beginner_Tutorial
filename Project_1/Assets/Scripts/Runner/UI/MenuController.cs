using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class MenuController : MonoBehaviour
    {

        private void Start()
        {
            TextureScrolling[] scrollingObjects = FindObjectsOfType<TextureScrolling>();
            foreach (TextureScrolling i in scrollingObjects)
            {
                i.InitForMenu();
            }
        }
        
        public void Play()
        {
            SceneManager.LoadScene("2DRunner");
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

