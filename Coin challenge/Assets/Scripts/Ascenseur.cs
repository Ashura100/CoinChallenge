using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascenseur : MonoBehaviour
{
    [SerializeField]
    Transform A, B;
    [SerializeField]
    Transform _plateform;
    [SerializeField]
    float vitesse = 0.1f;
    [SerializeField]
    List<EtageInfos> EtageInfosList;
    [SerializeField]
    List<PlaquePression> _presurePadsList;
    Coroutine corout;
    public int _currentFloor
    {
        get
        {
            return Mathf.RoundToInt(positionActuelle);
        }
    }
    float positionDepart
    {
        get
        {
            return Mathf.InverseLerp(A.position.y, B.position.y, _plateform.transform.position.y);
        }
    }

    float positionActuelle
    {
        get
        {
            float pointBas = A.position.y;
            float pointHaut = B.position.y;
            float pointActuel = _plateform.transform.position.y;
            return Mathf.InverseLerp(pointBas, pointHaut, pointActuel);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetAllPadActive(true);
    }
    //Fonction GoEtage met en marche la coroutine et affiche le num�ro de l'�tage dans la console
    public void GoEtage(int numEtage)
    {
        if (corout != null) return;
        Debug.Log("GoEtage" + numEtage);
        corout = StartCoroutine(GoEtageCorout(numEtage));
    }
    //Coroutine GoEtage permet de d�placer la plateforme en fonction de la liste d'�tage choisis gr�ce � leurs position 
    IEnumerator GoEtageCorout(int numEtage)
    {
        float positionDepart = positionActuelle;
        float positionCible = EtageInfosList[numEtage].T;

        if (positionDepart == positionCible) yield break;
        PersonnageController.instance.transform.SetParent(_plateform);
        PersonnageController.instance.rb.isKinematic = true;
        float _charSpeed = PersonnageController.instance.vitessePers;
        PersonnageController.instance.vitessePers = 0;
        PersonnageController.instance._col.enabled = false;

        SetAllPadActive(false);

        float t = 0;
        while (t < 1.1f)
        {
            t += Time.deltaTime * vitesse;
            float tBis = Mathf.Lerp(positionDepart, positionCible, t);//interpoler les positions entre Aet B en fonction de t
            Vector3 position = Vector3.Lerp(A.position, B.position, tBis);
            _plateform.position = position;
            yield return null;
        }
        PersonnageController.instance.transform.parent = null;
        PersonnageController.instance.rb.isKinematic = false;
        PersonnageController.instance.vitessePers = _charSpeed;
        PersonnageController.instance._col.enabled = true;

        PlaquePression _currentPad = GetPresurePadByLvl(_currentFloor);


        while (Vector3.Distance(PersonnageController.instance.transform.position, _currentPad.transform.position) < 20)
        {
            Debug.Log(Vector3.Distance(PersonnageController.instance.transform.position, _plateform.position));
            yield return null;
        }

        SetAllPadActive(true);

        corout = null;
    }

    //fonction qui active les plaques de pression
    void SetAllPadActive(bool _value)
    {
        foreach (var _pad in _presurePadsList)
        {
            _pad.SetActive(_value);
        }
    }
    //fonction qui fait apparaitre les plaque de pression en fcontion des �tages
    PlaquePression GetPresurePadByLvl(int _lvl)
    {
        foreach (var _pad in _presurePadsList)
        {
            if (_lvl == _pad.numEtage) return _pad;
        }

        return null;
    }

    //permet d'�tablir dans l'inspector le nombre d'�tage et leur position, T correspondant � la position des �tages
    [System.Serializable]
    public class EtageInfos
    {
        public int numerosEtage;
        public float T;
    }
}
