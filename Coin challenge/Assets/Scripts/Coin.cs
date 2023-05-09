using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, Iinteractable
{
    [SerializeField]
    public int coinValue;
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
            AudioSource.PlayClipAtPoint(CoinCollect, transform.position);
            ScoreManager.instance.AddCoins(coinValue);
            Destroy(gameObject);
    }
}
