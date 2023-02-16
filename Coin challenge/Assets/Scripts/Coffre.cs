using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffre : MonoBehaviour
{
    private Text interactUI;
    public Animator Anim;
    bool isInRange;
    /*[SerializeField]
    private AudioClip CoffreClip = null;

    private AudioSource porte_AudioSource;*/

    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
        //coffre_AudioSource = GetComponent<AudioSource>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& isInRange)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        Anim.SetTrigger("OuvrirCoffre");
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
        //coffre_AudioSource.PlayOneShot(CoffreClip);
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
