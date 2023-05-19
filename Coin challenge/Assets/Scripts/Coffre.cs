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

    public SpawnChest spawnChest;

    public bool isInteractable
    {
        get
        {
            return !Anim.GetBool("OuvrirCoffre");
        }

        set
        {

        }
    }
    //fonction permettant d'activer l'animation du coffre et l'audio d'ouverture
    void OpenChest()
    {
        spawnChest.mouveItems();
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
    //fonction d'interaction qui fait appel à la couroutine quand le joueur est bien dans le périmètre du coffre
    public void Interact(GameObject gameInteraction)
    {
        interactUI.enabled = false;
        if (gameInteraction.CompareTag("Player"))
        {
            StartCoroutine(Interactcouroute(gameInteraction));
            
            isInRange = true;

        }
    }
    //Fait appel à l'ouverture du coffre en fonction de la distance du joueur 
    IEnumerator Interactcouroute(GameObject player)
    {
        interactUI.enabled = true;
        while (Vector3.Distance(transform.position, player.transform.position) < 10f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                OpenChest();
            }
            yield return null;    
        }
    }
}
