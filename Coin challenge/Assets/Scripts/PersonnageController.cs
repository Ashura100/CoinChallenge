using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonnageController : MonoBehaviour
{
    public static PersonnageController instance;
    //struct stocke les directions et positions 

    [SerializeField]
    LifeSystem lifeSystem;
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
    public Rigidbody rb;
    [SerializeField]
    Animator animator;
    [SerializeField]
    private LayerMask groundMask;
    [SerializeField]
    public LayerMask enemyLayer;

    float currentWalk;
    float currentSpeed;
    float jumpheight;

    public float timeBetweenAttacks;
    float lastAttackTime;
    bool canAttack
    {
        get
        {
            if (Time.timeSinceLevelLoad - lastAttackTime < timeBetweenAttacks) return false;
            return true;
        }
    }
    [SerializeField]
    Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public int health = 100;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f * 5, 0);
        lifeSystem.onDieDel = OnDie;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lifeSystem.isAlife)
        {
            return;
        }

        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        direction = direction.normalized;

        if (direction.magnitude > 0.1f) 
        {
            MovePlayer();
            currentSpeed += Time.deltaTime * 2f;
        }
        else
        {
            currentSpeed -= Time.deltaTime * 5f;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, 2);

        animator.SetFloat("Speed", currentSpeed);

        //MovePlayerCamera();
        
        bool _isGrounded = IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        animator.SetBool("Jump", !_isGrounded);

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void MovePlayer()
    {
        float _targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        float _anle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref vitesseRotation, dureeRotation);
        transform.rotation = Quaternion.Euler(0f, _anle, 0f);
        Vector3 _moveDir = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
        _moveDir = _moveDir.normalized;
        rb.MovePosition(transform.position + (_moveDir * vitessePers * Time.deltaTime));
    }
    bool IsGrounded()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), Vector3.down);
        return (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, out hit, 0.5f, groundMask));
    }

    public void Attack()
    {
        if (!canAttack) return;
        StartCoroutine(timeCourout());
        lastAttackTime = Time.timeSinceLevelLoad;
    }

    IEnumerator timeCourout()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("Attack", false);
        Collider[] hitEnemis = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemis)
        {
            lastAttackTime = Time.timeSinceLevelLoad;
            enemy.GetComponent<LifeSystem>().TakeDamage(attackDamage);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        lifeSystem.healthbar.UpdateHealth();
        animator.SetTrigger("AsDamage");
        if (health < 0) Invoke(nameof(OnDie), 5f);
        
    }
    void OnDie()
    {
        animator.SetTrigger("IsDying");
        lifeSystem.onDieDel -= OnDie;
        StartCoroutine(waitForDeath());
    }

    IEnumerator waitForDeath()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameOver");
    }
}