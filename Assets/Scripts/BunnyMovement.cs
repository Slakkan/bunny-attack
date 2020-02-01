using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        if(transform.position.x > borderRange - 1)
        {
            maxRotation = 0;
        } else
        {
            maxRotation = initialMaxRotation;
        }

        if (transform.position.x < - (borderRange - 1))
        {
            minRotation = 0;
        }
        else
        {
            minRotation = initialMinRotation;
        }
    }

    IEnumerator Move()
    {
        while(!isAttacking)
        {
            facing = Random.Range(minRotation, maxRotation);
            facingInterval = Random.Range(1, 3);
            transform.eulerAngles = Vector3.up * facing;
            yield return new WaitForSeconds(facingInterval);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isAttacking = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isAttacking = false;
        }
    }
}
