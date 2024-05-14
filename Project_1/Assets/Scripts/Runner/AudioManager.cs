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
        [SerializeField] private AudioClip obstacleHit;
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClip recordReached;
    }
}

