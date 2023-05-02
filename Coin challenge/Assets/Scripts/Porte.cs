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
    private ScoreManager key;
    private AudioSource porte_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        key = FindObjectOfType<ScoreManager>();
        porte_AudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
        if (verrouiller)
        {
            if (key.key < 1)
                return;
            Anim.Play("PorteOuv");
            porte_AudioSource.PlayOneShot(PorteClip);
        }
            

        
    }

    void OnTriggerExit()
    {
        Anim.Play("PorteFermeture");
    }
}
