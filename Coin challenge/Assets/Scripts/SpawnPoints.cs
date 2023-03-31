using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField]
    private GameObject[] coins;
    [SerializeField]
    private SpawnInfos[] spawnPoints;

    void Start()
    {
        foreach(SpawnInfos spawnInfos in spawnPoints)
        {
            CreateCoins(spawnInfos);
        }
    }

    public void CreateCoins(SpawnInfos spawnInfos)
    {
        
        if (spawnInfos.coinInst != null)
            return;
        int coinIndex = Random.Range(0, coins.Length);
        spawnInfos.coinInst = Instantiate(coins[coinIndex]);
        spawnInfos.coinInst.transform.position = spawnInfos.spawnPose.position;
        spawnInfos.coinInst.transform.SetParent(transform);
    }

    [System.Serializable]
    public class SpawnInfos
    {
        public Transform spawnPose;
        public GameObject coinInst;
    }
}
