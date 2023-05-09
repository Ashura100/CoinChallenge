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
        spawnInfos.itemsInst = Instantiate(items[spawnInfos.prefabIndex]);
        spawnInfos.itemsInst.transform.position = spawnInfos.spawnPose.position;
        spawnInfos.itemsInst.transform.SetParent(transform);
        spawnInfos.itemsInst.gameObject.SetActive(false);
        spawnInfos.iinteractable = spawnInfos.itemsInst.GetComponent<Iinteractable>();
        spawnInfos.iinteractable.isInteractable = false;
    }

    public void mouveItems()
    {
        foreach(SpawnInfos spawnInfos in spawnPoints)
        {
            StartCoroutine(MouveItemsCorout(spawnInfos));
        }
    }

    IEnumerator MouveItemsCorout(SpawnInfos spawnInfos)
    {
        spawnInfos.itemsInst.gameObject.SetActive(true);
        Vector3 startPos = spawnInfos.spawnPose.position;
        Vector3 targetPos = startPos + new Vector3(0, 2, 0);
        float t = 0;
        while (t < 1)
        {
            spawnInfos.itemsInst.transform.position = Vector3.Lerp(startPos, targetPos, t);
            t += Time.deltaTime;
            yield return null;
        }
        spawnInfos.iinteractable.isInteractable = true;
    }

    [System.Serializable]
    public class SpawnInfos
    {
        public Transform spawnPose;
        public GameObject itemsInst;
        public int prefabIndex;
        public Iinteractable iinteractable;
    }
}
