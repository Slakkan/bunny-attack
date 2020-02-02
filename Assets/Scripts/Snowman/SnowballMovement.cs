using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float impulseForce = 10;
    public Vector3 impulseAngle;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 sideSpeed = new Vector3(0, 0, 0);
        impulseAngle = transform.up + transform.forward;
        if(Input.GetAxis("Vertical") != 0)
        {
            sideSpeed = new Vector3(-Input.GetAxis("Vertical"), 0, 0);
        }
        
        rb.AddForce((impulseAngle + sideSpeed) * impulseForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0.2f)
        {
            Destroy(gameObject);
        }
    }
}
