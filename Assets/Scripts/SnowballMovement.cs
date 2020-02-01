using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float impulseForce = 5;
    public Vector3 impulseAngle;
    // Start is called before the first frame update
    void Start()
    {
        impulseAngle = transform.up + transform.forward;
        rb.AddForce(impulseAngle * impulseForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
