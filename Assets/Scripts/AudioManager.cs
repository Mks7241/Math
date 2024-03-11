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
    [SerializeField] AudioClip breakWall;
    [SerializeField] AudioClip death;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
