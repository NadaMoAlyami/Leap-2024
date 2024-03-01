using UnityEngine;

public class SoundCotroller : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 0f;
    private bool isPlaying = false;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void SetVolume(float vol)
    {
        if (vol > 0f && !isPlaying)
        {
            // If volume is increased from zero and sound is not playing
            musicVolume = vol;
            audioSrc.volume = musicVolume;
            audioSrc.Play();
            isPlaying = true;
        }
        else if (vol == 0f && isPlaying)
        {
            // If volume is set back to zero and sound is playing
            audioSrc.Stop();
            isPlaying = false;
        }
        else
        {
            // Adjust volume otherwise
            musicVolume = vol;
            audioSrc.volume = musicVolume;
        }
    }
}



