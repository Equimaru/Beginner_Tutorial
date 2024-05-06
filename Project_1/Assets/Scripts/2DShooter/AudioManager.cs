using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private AudioSource _audioSource;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip missSound;
    [SerializeField] private AudioClip reloadSound;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        _audioSource.clip = hitSound;
        _audioSource.Play();
    }

    public void PlayMissSound()
    {
        _audioSource.clip = missSound;
        _audioSource.Play();
    }

    public void PlayReloadSound()
    {
        _audioSource.clip = reloadSound;
        _audioSource.Play();
    }
}
