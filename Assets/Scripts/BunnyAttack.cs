using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAttack : MonoBehaviour
{

    public float atackInterval = 1;
    Transform currentTarget;

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            InvokeRepeating("Attack", atackInterval, atackInterval);
            currentTarget = collision.transform;
        }
    }

    void Attack()
    {
        if(currentTarget != null)
        {
            currentTarget.GetComponent<WallStatus>().Damage();
        } else
        {
            CancelInvoke("Attack");
        }
    }
}
