using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    [SerializeField]
    private Animation Anim;
    [SerializeField]
    bool verrouiller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (verrouiller)
            return;

        Anim.Play("PorteOuv");
    }

    void OnTriggerExit()
    {
        Anim.Play("PorteFermeture");
    }
}
