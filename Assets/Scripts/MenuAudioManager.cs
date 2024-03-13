using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [Header("----AudioSource----")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    [Header("----SfxSource----")]
    public AudioClip background; 
    public AudioClip click; 

    public void PlayMenuBackgroundMusic()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlayMenuClickSound(AudioClip Clip)
    {
        sfxSource.clip = Clip;
        sfxSource.Play();
    }
     
}
