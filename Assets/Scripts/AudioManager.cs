using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------AudioSource----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------AudioClip--------")]
    [SerializeField] AudioClip background;
    public AudioClip breakWall;
    public AudioClip death;
    public AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        Debug.Log("music");
        
    }
    public void PlaySfx(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
