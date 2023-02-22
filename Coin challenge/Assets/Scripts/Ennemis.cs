using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    [SerializeField]
    private AudioClip ZombieClip = null;
    public Transform target;
    public float speed = 4f;
    Rigidbody rb;
    private AudioSource zombie_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        zombie_AudioSource = GetComponent<AudioSource>();
        zombie_AudioSource.PlayOneShot(ZombieClip);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed*Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }
}
