using UnityEngine;

namespace Catch
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")] 
        [SerializeField] private AudioSource player;
        [SerializeField] private AudioSource gatekeeper;
        [SerializeField] private AudioSource healthSystem;
        
        [Header("Audio Clips")]
        [SerializeField] private AudioClip catchClip;
        [SerializeField] private AudioClip dropClip;
        [SerializeField] private AudioClip explosionClip;
    }

}
