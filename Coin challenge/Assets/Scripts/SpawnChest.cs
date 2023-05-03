using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private SpawnInfos[] spawnPoints;
    void Start()
    {
        foreach (SpawnInfos spawnInfos in spawnPoints)
        {
            CreateItems(spawnInfos);
        }
    }

    public void CreateItems(SpawnInfos spawnInfos)
    {

        if (spawnInfos.itemsInst != null)
            return;
        int itemsIndex = Random.Range(0, items.Length);
        spawnInfos.itemsInst = Instantiate(items[itemsIndex]);
        spawnInfos.itemsInst.transform.position = spawnInfos.spawnPose.position;
        spawnInfos.itemsInst.transform.SetParent(transform);
    }

    [System.Serializable]
    public class SpawnInfos
    {
        public Transform spawnPose;
        public GameObject itemsInst;
    }
}
