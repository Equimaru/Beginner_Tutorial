using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class MenuController : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI record;

        private int _currentRecord;
        
        private void Start()
        {
            TextureScrolling[] scrollingObjects = FindObjectsOfType<TextureScrolling>();
            foreach (TextureScrolling i in scrollingObjects)
            {
                i.InitForMenu();
            }

            _currentRecord = ScoreSystem.Instance.currentRecord;
            record.text = $"Record: {_currentRecord}";
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

