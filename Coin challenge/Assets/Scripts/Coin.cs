using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coins;

    private void Start()
    {
        ScoreManager.instance.AddPoint();
    }
    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coins")
        {
            Debug.Log("coin collect");
            coins = coins + 1;
            Col.gameObject.SetActive(false);
        }
    }
}
