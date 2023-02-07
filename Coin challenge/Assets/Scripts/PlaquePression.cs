using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaquePression : MonoBehaviour
{
    public Ascenseur ascenceur;
    [SerializeField]
    int numEtage;

    void OnTriggerEnter(Collider col)
    {
        ascenceur.GoEtage(numEtage);
    }

    void OnTriggerExit(Collider col)
    {
    
    }
}
