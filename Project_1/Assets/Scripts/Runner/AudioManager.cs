using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource q1;
        [SerializeField] private AudioSource q2;
        [SerializeField] private AudioSource q3;
        [SerializeField] private AudioSource q4;

        [Header("Audio Clips")] 
        [SerializeField] private AudioClip c1;
        [SerializeField] private AudioClip c2;
        [SerializeField] private AudioClip c3;
        [SerializeField] private AudioClip c4;
    }
}

