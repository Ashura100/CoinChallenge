using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemis : MonoBehaviour
{
    [SerializeField]
    private AudioClip ZombieClip = null;
    [SerializeField] private Transform _movePosTransform;
    private NavMeshAgent _navMeshAgent;
    public Transform player;
    public LayerMask playerMask, groundMask;
    Rigidbody rb;
    private AudioSource zombie_AudioSource;
    //patrouille
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //attaque
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float health;
    void Awake()
    {
        player = GameObject.Find("Personnage").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        zombie_AudioSource = GetComponent<AudioSource>();
        zombie_AudioSource.PlayOneShot(ZombieClip);
    }

    void FixedUpdate()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInSightRange && !playerInAttackRange) Patrouille();
        if (playerInSightRange && !playerInAttackRange) Poursuite();
        if (playerInSightRange && playerInAttackRange) Attaque();

    }
    void Patrouille()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            _navMeshAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
            walkPointSet = true;
    }
    void Poursuite()
    {
        _navMeshAgent.SetDestination(player.position);
    }

    void Attaque()
    {
        _navMeshAgent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ArretAttaque), timeBetweenAttacks);
        }
    }
    void ArretAttaque()
    {
        alreadyAttacked = false;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) Invoke(nameof(Die), 5f);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
