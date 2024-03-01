using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
 private AudioSource audioSrc;
    private float musicVolume = 0f;
    private bool shouldPlay = false;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        // Start playing the sound
        audioSrc.Play();
        // Pause the sound
        audioSrc.Pause();
    }

    public void SetVolume(float vol)
    {
        if (vol > 0f && !shouldPlay)
        {
            // If volume is increased from zero and sound should not be playing
            musicVolume = vol;
            audioSrc.volume = musicVolume;
            audioSrc.UnPause(); // Unpause the sound
            shouldPlay = true;
        }
        else if (vol == 0f && shouldPlay)
        {
            // If volume is set back to zero and sound should be playing
            audioSrc.Pause(); // Pause the sound
            shouldPlay = false;
        }
        else
        {
            // Adjust volume otherwise
            musicVolume = vol;
            audioSrc.volume = musicVolume;
        }
    }
}



