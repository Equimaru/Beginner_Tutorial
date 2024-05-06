using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource weaponSystemAudioSource;
    [SerializeField] private AudioSource ammunitionSystemAudioSource;
    [SerializeField] private AudioSource spawnSystemAudioSource;
    [SerializeField] private AudioSource dispawnSystemAudioSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip backgroundMusic;
    
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip missSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private AudioClip dispawnSound;


    private void Start()
    {
        musicAudioSource.clip = backgroundMusic;
        musicAudioSource.Play();
    }
    
    public void PlayHitSound()
    {
        weaponSystemAudioSource.clip = hitSound;
        weaponSystemAudioSource.Play();
    }

    public void PlayMissSound()
    {
        weaponSystemAudioSource.clip = missSound;
        weaponSystemAudioSource.Play();
    }

    public void PlayReloadSound()
    {
        ammunitionSystemAudioSource.clip = reloadSound;
        ammunitionSystemAudioSource.Play();
    }

    public void PlaySpawnSound()
    {
        spawnSystemAudioSource.clip = spawnSound;
        spawnSystemAudioSource.Play();
    }
    
    public void PlayDispawnSound()
    {
        dispawnSystemAudioSource.clip = dispawnSound;
        dispawnSystemAudioSource.Play();
    }
}
