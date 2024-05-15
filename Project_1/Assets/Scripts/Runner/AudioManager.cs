using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource player;
        [SerializeField] private AudioSource music;
        [SerializeField] private AudioSource scoreSystem;

        [Header("Audio Clips")] 
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip crash;
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClip recordBroke;

        public void PlayJumpSound()
        {
            player.clip = jump;
            player.Play();
        }
        
        public void PlayCrashSound()
        {
            player.clip = crash;
            player.Play();
        }
        
        public void PlayBackgroundMusic()
        {
            music.clip = backgroundMusic;
            music.Play();
        }
        
        public void PlayRecordBrokeSound()
        {
            scoreSystem.clip = recordBroke;
            scoreSystem.Play();
        }
    }
}

