using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Iinteractable
{
    [SerializeField]
    private AudioClip CoinCollect = null;
    [SerializeField]
    bool canBeCollected = true;
    public bool isInteractable
    {
        get
        {
            return true;
        }
        set
        {
            canBeCollected = value;
        }
    }
    

    public void Interact(GameObject gameInteraction)
    {
        Debug.Log("key");
        AudioSource.PlayClipAtPoint(CoinCollect, transform.position);
        ScoreManager.instance.AddKeys();
        Destroy(gameObject);
    }
}