using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascenceur : MonoBehaviour
{
    [SerializeField]
    Transform A, B;
    [SerializeField]
    Rigidbody rigidBody;
    [SerializeField]
    float vitesse = 1;
    [SerializeField]
    List<EtageInfos> EtageInfosList;
    float positionDepart
    {
        get
        {
            return Mathf.InverseLerp(A.position.y, B.position.y, rigidBody.transform.position.y);
        }
    }

    float positionActuelle
    {
        get
        {
            float pointBas = A.position.y;
            float pointHaut = B.position.y;
            float pointActuel = rigidBody.transform.position.y;
            return Mathf.InverseLerp(pointBas, pointHaut, pointActuel);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void GoEtage(int numEtage)
    {
        StartCoroutine(GoEtageCorout(numEtage));
    }
    // Update is called once per frame
    IEnumerator GoEtageCorout(int numEtage)
    {
        float positionDepart = positionActuelle;
        float positionCible = EtageInfosList[numEtage].T;
        if (positionDepart == positionCible) yield break;
        float t = 0;
        while (t < 1.1f) 
        {
            t += Time.deltaTime;
            float tBis = Mathf.Lerp(positionDepart, positionCible, t);
            Vector3 position = Vector3.Lerp(A.position, B.position, tBis);
            rigidBody.MovePosition(position);
        }
        yield return null;
    }
    [System.Serializable]
    public class EtageInfos
    {
        public int numeroEtage;
        public float T; 
    }
}
