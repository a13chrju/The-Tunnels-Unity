using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agenMove : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform player;
    Animator anim;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        nav.SetDestination(player.position);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = nav.velocity.magnitude / nav.speed;
        anim.SetFloat("walkingSpeed", speed);
        float dist = Vector3.Distance(player.position, transform.position);
        float distY = transform.position.y - player.transform.position.y;

        if (distY < -1)
        {
            // Debug.Log(distY);
            nav.isStopped = true;
            return;
        }

        if (dist > 5)
        {
            nav.isStopped = false;
            nav.SetDestination(player.position);
        }

    }
}
