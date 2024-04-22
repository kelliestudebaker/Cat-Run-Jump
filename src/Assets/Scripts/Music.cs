using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip music;

    void Start() //Play music once the scene has started.
    {
        musicSource.clip = music;
        musicSource.Play();
    }
}