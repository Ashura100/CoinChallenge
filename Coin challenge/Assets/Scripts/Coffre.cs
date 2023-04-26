using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffre : MonoBehaviour, Iinteractable
{
    [SerializeField]
    private Text interactUI;

    public Animator Anim;
    bool isInRange;
    [SerializeField]
    private AudioClip CoffreClip = null;

    public bool isInteractable
    {
        get
        {
            return !Anim.GetBool("OuvrirCoffre");
        }
    }
    //fonction permettant d'activer l'animation du coffre et l'audio d'ouverture
    void OpenChest()
    {
        Anim.SetBool("OuvrirCoffre", true);
        AudioSource.PlayClipAtPoint(CoffreClip, transform.position);
    }
    //une fois sortie de la zone du collider désactive le texte d'interaction et la zone d'interaction
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }

    public void Interact(GameObject gameInteraction)
    {
        if (gameInteraction.CompareTag("Player"))
        {
            StartCoroutine(Interactcouroute(gameInteraction));
            
            isInRange = true;
            Debug.Log(gameInteraction.name);

        }
    }

    IEnumerator Interactcouroute(GameObject player)
    {
        interactUI.enabled = true;
        while (Vector3.Distance(transform.position, player.transform.position) < 5f)
        {
            Debug.Log("while");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                OpenChest();
            }
            yield return null;    
        }
    }
}
