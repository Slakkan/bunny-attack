using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Status
{
    untouched,
    damaged,
    broken,
    destroyed
}

public class WallStatus : MonoBehaviour
{
    Status status;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("SnowBall"))
        {
            Repair();
            Destroy(collision.gameObject);
        }
    }


    public void Damage()
    {
        status++;
        Debug.Log(status);
        if(status == Status.destroyed)
        {
            Destroy(gameObject);
        }
    }

    void Repair()
    {
        if(status != 0 )
        {
            status--;
        }        
    }
}
