using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    [SerializeField]
    private Animation Anim;
    [SerializeField]
    bool verrouiller;
    [SerializeField]
    private AudioClip PorteClip = null;

    private AudioSource porte_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        porte_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (verrouiller)
            return;

        Anim.Play("PorteOuv");
        porte_AudioSource.PlayOneShot(PorteClip);
    }

    void OnTriggerExit()
    {
        Anim.Play("PorteFermeture");
    }
}
