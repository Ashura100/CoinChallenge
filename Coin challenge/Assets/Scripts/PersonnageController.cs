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
    float jumpForce;
    [SerializeField]
    float vitessePers = 10;
    [SerializeField]
    Camera cam;
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Animator animator;
    [SerializeField]
    private LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        direction = direction.normalized;

        if (direction.magnitude > 0.1f) MovePlayer();

        animator.SetBool("IsRunning", direction.magnitude > 0.1f);
        //MovePlayerCamera();
    }

    void MovePlayer()
    {
        float _targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        float _anle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref vitesseRotation, dureeRotation);
        transform.rotation = Quaternion.Euler(0f, _anle, 0f);
        Vector3 _moveDir = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
        _moveDir = _moveDir.normalized;
        rb.MovePosition(transform.position + (_moveDir * vitessePers * Time.deltaTime));

        bool _isGrounded = IsGrounded();

        animator.SetBool("IsJumping", !_isGrounded);


        if (Input.GetKeyDown(KeyCode.Space)) Debug.Log(_isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f, groundMask))
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }
}