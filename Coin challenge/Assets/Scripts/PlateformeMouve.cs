using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMouve : MonoBehaviour
{
    [SerializeField]
    Transform A, B;
    [SerializeField]
    Rigidbody rigidBody;
    [SerializeField]
    float vitesse = 1;

    Vector3 a, b;

    // Start is called before the first frame update
    void Start()
    {
        a = A.transform.position;
        b = B.transform.position;
    }

    //permet de déplacer la plateforme en fonction de la position du point A et B
    void Update()
    {
        float t = Mathf.InverseLerp(-1, 1, Mathf.Sin(Time.timeSinceLevelLoad * vitesse));
        rigidBody.MovePosition(Vector3.Lerp(a, b, t));
    }
}