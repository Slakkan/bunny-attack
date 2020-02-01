using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject snowball;
    public Vector3 snowballOffset = new Vector3(+0.5f, 0, 0);
    float chargeStart;
    float chargeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCharging();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCharging();
        }
    }

    void StartCharging()
    {
        chargeStart = Time.time;
    }

    void StopCharging()
    {
        chargeTime = Time.time - chargeStart;
        Shoot();
    }

    void Shoot()
    {
        GameObject newBall = Instantiate<GameObject>(snowball, transform.position - snowballOffset, snowball.transform.rotation);
        SnowballMovement movement = newBall.GetComponent<SnowballMovement>();
        movement.impulseForce = Mathf.Min(8, 5 + chargeTime);
    }
}
