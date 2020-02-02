using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BunnyMovement : MonoBehaviour
{
    bool isAttacking;
    public bool isRetrating;
    float facing;
    float facingInterval;
    float speed = 3;
    float minRotation = -45;
    float initialMinRotation = -45;
    float maxRotation = 45;
    float initialMaxRotation = 45;
    float borderRange = 25;
    public Rigidbody rb;
    public NavMeshAgent navAgent;
    private Transform playerTransform;
    public Animator animator;
    private float chaseDistance = -5;
    Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        StartCoroutine(ChangeFacing());
        InvokeRepeating("ChasePlayer", 0, 0.1f);
        playerTransform = GameObject.Find("Snowman").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRetrating && transform.position.z <= chaseDistance && navAgent.pathStatus.Equals(NavMeshPathStatus.PathComplete))
        {
            move();
        }

        if (isRetrating && Vector3.Distance(transform.position, initialPos) < 0.5f)
        {
            Destroy(gameObject);
        }
    }

    void ChasePlayer()
    {
        if(!isRetrating && transform.position.z > chaseDistance)
        {
            navAgent.SetDestination(playerTransform.position);
        }
    }

    void move()
    {
        rb.velocity = transform.forward * speed;
        if (transform.position.x > borderRange - 1)
        {
            maxRotation = 0;
            RandomFacing();
        }
        else
        {
            maxRotation = initialMaxRotation;
        }

        if (transform.position.x < -(borderRange - 1))
        {
            minRotation = 0;
            RandomFacing();
        }
        else
        {
            minRotation = initialMinRotation;
        }
    }

    public void Retreat()
    {
        isRetrating = true;
        isAttacking = false;
        animator.SetBool("isKicking" ,isAttacking);
        navAgent.SetDestination(initialPos);
    }

    IEnumerator ChangeFacing()
    {
        while(!isRetrating && !isAttacking && transform.position.z <= chaseDistance && navAgent.pathStatus.Equals(NavMeshPathStatus.PathComplete))
        {
            RandomFacing();
            yield return new WaitForSeconds(facingInterval);
        }
    }

    void RandomFacing()
    {
        facing = Random.Range(minRotation, maxRotation);
        facingInterval = Random.Range(1, 3);
        transform.eulerAngles = Vector3.up * facing;
    }

    void AvoidOtherBunnies(float otherPosX)
    {
        if(otherPosX < transform.position.x)
        {
            minRotation = 0;
            RandomFacing();
        } else
        {
            maxRotation = 0;
            RandomFacing();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isRetrating && collision.gameObject.CompareTag("Wall"))
        {
            isAttacking = true;
            animator.SetBool("isKicking", isAttacking);
        }

        if (collision.gameObject.CompareTag("Bunny"))
        {
            AvoidOtherBunnies(collision.gameObject.transform.position.x);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (!isRetrating && collision.gameObject.CompareTag("Wall"))
        {
            isAttacking = false;
            animator.SetBool("isKicking", isAttacking);
            navAgent.SetDestination(transform.position + 2 * Vector3.forward);
        }
    }
}
