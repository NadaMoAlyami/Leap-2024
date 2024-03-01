using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{

    private AudioSource audioSrc;
    private float musicVolume = 0f;
    private bool isPlaying = false;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        // Start the sound at zero volume
        audioSrc.volume = 0f;
        // Start playing the sound
        audioSrc.Play();
        // Pause the sound
        audioSrc.Pause();
    }

    public void SetVolume(float vol)
    {
        if (vol > 0f && !isPlaying)
        {
            // If volume is increased from zero and sound is not playing
            musicVolume = vol;
            audioSrc.volume = musicVolume;
            audioSrc.UnPause(); // Unpause the sound
            isPlaying = true;
        }
        else if (vol == 0f && isPlaying)
        {
            // If volume is set back to zero and sound is playing
            audioSrc.Pause(); // Pause the sound
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


