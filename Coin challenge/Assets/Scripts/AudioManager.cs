using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip ambiance;
    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        playMusic();
    }
    public static void playMusic()
    {
        instance.audioSource.clip = instance.ambiance;
        instance.audioSource.Play();
    }
    public static void playMusic(AudioClip audioClip)
    {
        instance.audioSource.clip = audioClip;
        instance.audioSource.Play();
    }
}
