using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource firstAudioSource;
    public AudioSource secondAudioSource;

    private bool isFirstAudioPlaying = false;

    private void Start()
    {
        // Play the first audio source on awake
        firstAudioSource.Play();
        isFirstAudioPlaying = true;
    }

    private void Update()
    {
        // Check if the first audio source has finished playing
        if (isFirstAudioPlaying && !firstAudioSource.isPlaying)
        {
            // Play the second audio source
            secondAudioSource.Play();
            isFirstAudioPlaying = false; // Ensure we don't play it again
        }
    }
}
