using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffre : MonoBehaviour
{
    private Text interactUI;
    public Animator Anim;
    bool isInRange;
    [SerializeField]
    private AudioClip CoffreClip = null;

    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

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
            AudioSource.PlayClipAtPoint(CoffreClip, transform.position);

        }
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
