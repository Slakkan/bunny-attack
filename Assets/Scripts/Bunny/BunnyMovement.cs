using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BunnyMovement : MonoBehaviour
{
    bool isAttacking;
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
    private float chaseDistance = -5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeFacing());
        InvokeRepeating("ChasePlayer", 0, 0.1f);
        playerTransform = GameObject.Find("Snowman").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= chaseDistance && navAgent.pathStatus.Equals(NavMeshPathStatus.PathComplete))
        {
            move();
        }
    }

    void ChasePlayer()
    {
        if(transform.position.z > chaseDistance)
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

    IEnumerator ChangeFacing()
    {
        while(!isAttacking && transform.position.z <= chaseDistance && navAgent.pathStatus.Equals(NavMeshPathStatus.PathComplete))
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
        if (collision.gameObject.CompareTag("Wall"))
        {
            isAttacking = true;
        }

        if (collision.gameObject.CompareTag("Bunny"))
        {
            AvoidOtherBunnies(collision.gameObject.transform.position.x);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isAttacking = false;
            navAgent.SetDestination(transform.position + 2 * Vector3.forward);
        }
    }
}
