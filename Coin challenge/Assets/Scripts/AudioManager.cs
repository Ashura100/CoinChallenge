using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    AudioSource audioSource;
    void Awake()
    {
        instance = this; 
    }

    public static void playMusic(AudioClip audioClip)
    {
        instance.audioSource.clip = audioClip;
        instance.audioSource.Play();
    }
}
