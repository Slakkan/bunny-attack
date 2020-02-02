using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioSource throwAudio;
    public GameObject snowball;
    public float powerMin = 3;
    public float powerMax = 6;
    public float chargeSpeed = 3;
    float chargeStart;
    float chargeTime;
    public Animator animator;
    public GameObject arma;
    public GameObject throwBar;
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
        throwBar.SetActive(true);
        chargeStart = Time.time;
    }

    void StopCharging()
    {
        chargeTime = (Time.time - chargeStart) * chargeSpeed;
        Shoot();
    }

    void ThrowBall()
    {
        GameObject newBall = Instantiate<GameObject>(snowball, arma.transform.position, snowball.transform.rotation);
        SnowballMovement movement = newBall.GetComponent<SnowballMovement>();
        Debug.Log(powerMin);
        Debug.Log(powerMax);
        Debug.Log(chargeTime);
        movement.impulseForce += Mathf.Min(powerMax, powerMin + chargeTime);
    }

    void Shoot()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            throwAudio.Play();
            animator.SetTrigger("Attack");
        }
    }
}
