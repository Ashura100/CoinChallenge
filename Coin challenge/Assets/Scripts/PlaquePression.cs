using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaquePression : MonoBehaviour
{

    public Ascenseur ascenceur;
    public int numEtage;

    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        ascenceur.GoEtage(numEtage);
    }

    void OnTriggerExit(Collider col)
    {
    
    }

    public void SetActive(bool _value)
    {
        if (_value && ascenceur._currentFloor == numEtage) _value = false;
            gameObject.SetActive(_value);

    }
}
