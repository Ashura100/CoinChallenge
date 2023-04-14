using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioManager.playMusic(audioClip);
        }
    }
}
