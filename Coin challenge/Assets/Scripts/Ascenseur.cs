using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascenseur : MonoBehaviour
{
    [SerializeField]
    Transform A, B;
    [SerializeField]
    Rigidbody rigidBody;
    [SerializeField]
    float vitesse = 0.1f;
    [SerializeField]
    List<EtageInfos> EtageInfosList;
    Coroutine corout;
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
        if (corout != null) return;
        Debug.Log("GoEtage" + numEtage);
        corout = StartCoroutine(GoEtageCorout(numEtage));
    }
    // Update is called once per frame
    IEnumerator GoEtageCorout(int numEtage)
    {
        PersonnageController.instance.transform.SetParent(rigidBody.transform);
        PersonnageController.instance.rb.isKinematic = true;
        float positionDepart = positionActuelle;
        float positionCible = EtageInfosList[numEtage].T;
        float DeltaT = Mathf.Abs(positionCible - positionDepart);
        Debug.Log(positionDepart + " " + positionCible);
        if (positionDepart == positionCible) yield break;
        float t = 0;
        while (t < 1.1f) 
        {
            t += Time.deltaTime * vitesse * DeltaT;
            float tBis = Mathf.Lerp(positionDepart, positionCible, t);
            Vector3 position = Vector3.Lerp(A.position, B.position, tBis);
            rigidBody.MovePosition(position);
            yield return null;
        }
        PersonnageController.instance.transform.parent = null;
        PersonnageController.instance.rb.isKinematic = false;
        corout = null;
    }
    [System.Serializable]
    public class EtageInfos
    {
        public int numerosEtage;
        public float T; 
    }
}
