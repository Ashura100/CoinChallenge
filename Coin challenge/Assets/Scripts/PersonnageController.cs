using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{
    //struct stocke les directions et positions 
    Vector3 direction;
    float vitesseRotation;
    float dureeRotation = 0.05f;
    [SerializeField]
    float vitessePers = 10;
    [SerializeField]
    Camera cam;
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        direction = direction.normalized;
        //indique la longueur du vector
        if (direction.magnitude > 0.1f)
        {
            Mouvement();
        }
        animator.SetBool("IsRunning", direction.magnitude > 0.1f);
    }
    void Mouvement()
    {
        //calcul de la direction du personnage en fonction de la camera
        float angleCible = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleCible, ref vitesseRotation, dureeRotation);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        Vector3 directionMouvement = Quaternion.Euler(0, angleCible, 0)* Vector3.forward;
        directionMouvement = directionMouvement.normalized;
        rb.MovePosition(transform.position + (vitessePers * directionMouvement * Time.deltaTime));
    }
}
