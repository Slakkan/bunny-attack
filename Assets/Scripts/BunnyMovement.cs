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
            ChangeFacing();
        } else
        {
            maxRotation = initialMaxRotation;
        }

        if (transform.position.x < - (borderRange - 1))
        {
            minRotation = 0;
            ChangeFacing();
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
            ChangeFacing();
            yield return new WaitForSeconds(facingInterval);
        }
    }

    void ChangeFacing()
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
            ChangeFacing();
        } else
        {
            maxRotation = 0;
            ChangeFacing();
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
        }
    }
}
