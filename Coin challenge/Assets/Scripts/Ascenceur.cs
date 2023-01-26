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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    IEnumerator GoEtage(int numEtage)
    {
        float t = Mathf.InverseLerp(-1, 1, Mathf.Sin(Time.timeSinceLevelLoad * vitesse));
        rigidBody.MovePosition(Vector3.Lerp(A.position, B.position, t));
        yield return null;
    }
    [System.Serializable]
    public class EtageInfos
    {
        public int numeroEtage;
        public float T; 
    }
}
