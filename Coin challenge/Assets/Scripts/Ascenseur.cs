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
    //Fonction GoEtage met en marche la coroutine et affiche le numéro de l'étage dans la console
    public void GoEtage(int numEtage)
    {
        if (corout != null) return;
        Debug.Log("GoEtage" + numEtage);
        corout = StartCoroutine(GoEtageCorout(numEtage));
    }
    //Coroutine GoEtage permet de déplacer la plateforme en fonction de la liste d'étage choisis grâce à leurs position 
    IEnumerator GoEtageCorout(int numEtage)
    {
        float positionDepart = positionActuelle;
        float positionCible = EtageInfosList[numEtage].T;
        float DeltaT = Mathf.Abs(positionCible - positionDepart);
        Debug.Log(positionDepart + " " + positionCible);
        if (positionDepart == positionCible) yield break;
        PersonnageController.instance.transform.SetParent(rigidBody.transform);
        PersonnageController.instance.rb.isKinematic = true;
        float t = 0;
        while (t < 1.1f) 
        {
            t += Time.deltaTime * vitesse * DeltaT;
            float tBis = Mathf.Lerp(positionDepart, positionCible, t);//interpoler les positions entre Aet B en fonction de t
            Vector3 position = Vector3.Lerp(A.position, B.position, tBis);
            rigidBody.MovePosition(position);
            yield return null;
        }
        PersonnageController.instance.transform.parent = null;
        PersonnageController.instance.rb.isKinematic = false;
        corout = null;
    }

    //permet d'établir dans l'inspector le nombre d'étage et leur position, T correspondant à la position des étages
    [System.Serializable]
    public class EtageInfos
    {
        public int numerosEtage;
        public float T; 
    }
}
