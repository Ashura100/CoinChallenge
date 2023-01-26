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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.InverseLerp(-1, 1, Mathf.Sin(Time.timeSinceLevelLoad*vitesse));
        rigidBody.MovePosition(Vector3.Lerp(A.position, B.position, t));
    }
}
