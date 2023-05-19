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
    public float vitessePers = 10;
    float playerSpeedRate;
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
    public Collider _col;

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
    bool alreadyAttacked = false;
    [SerializeField]
    Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public int health = 100;
    float _currentSpeed;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lifeSystem.onDieDel = OnDie;
        Physics.gravity = new Vector3(0, -9.81f * 5, 0);
    }

    // Update is called once per frame 
    void Update()
    {
        //transform.LookAt(target, Vector3.up);
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        direction = direction.normalized;

        if (direction.magnitude > 0.1f)
        {
            MovePlayer();
            _currentSpeed += Time.deltaTime * 5;
            playerSpeedRate += Time.deltaTime*3f;

        }
        else
        {
            _currentSpeed -= Time.deltaTime * 5f;
            playerSpeedRate -= Time.deltaTime*5f;
        }

        _currentSpeed = Mathf.Clamp(_currentSpeed, 0, 1);
        playerSpeedRate = Mathf.Clamp(playerSpeedRate, 0, 1);

        animator.SetFloat("Run_Speed", _currentSpeed);
        
        bool _isGrounded = IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = true;
        }

        animator.SetBool("IsJumping", !_isGrounded);

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    //fonction qui calcul les mouvements de la camera du joueur et du joueur 
    void MovePlayer()
    {
        float _targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        float _anle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref vitesseRotation, dureeRotation);
        transform.rotation = Quaternion.Euler(0f, _anle, 0f);
        Vector3 _moveDir = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
        _moveDir = _moveDir.normalized;
        rb.MovePosition(transform.position + (_moveDir * (vitessePers * playerSpeedRate) * Time.deltaTime));
    }
    //fonction qui permet d'établir si le joueur touche le sol grâce à un raycast
    bool IsGrounded()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), Vector3.down);
        return (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, out hit, 0.4f, groundMask));
    }

    public void Attack()
    {
        if (alreadyAttacked) return;
        StartCoroutine(AttackCorout());
    }

    IEnumerator AttackCorout()
    {
        animator.SetTrigger("IsAttacking");

        alreadyAttacked = true;
        float t = 0;
        while (t < 0.7f) { t += Time.deltaTime; yield return null; }
        Collider[] hitEnemis = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);


        foreach (Collider enemy in hitEnemis)
        {
            lastAttackTime = Time.timeSinceLevelLoad;
            LifeSystem _lifeSystem = enemy.GetComponent<LifeSystem>();
            if (_lifeSystem == null) continue;
            Debug.Log(_lifeSystem.gameObject.name);
            _lifeSystem.TakeDamage(attackDamage);

        }
        t = 0;
        while (t < 0.1f) { t += Time.deltaTime; yield return null; }

        alreadyAttacked = false;

    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        lifeSystem.healthbar.UpdateHealth();
        if (health < 0) Invoke(nameof(OnDie), 5f);

    }
    void OnDie()
    {
        animator.SetTrigger("IsDying");
        SceneManager.LoadScene("GameOver");
        lifeSystem.onDieDel -= OnDie;
    }
}