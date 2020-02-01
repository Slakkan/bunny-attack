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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnowBall"))
        {
            Repair();
            Destroy(other.gameObject);
        }
    }

    public void Damage()
    {
        status++;
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
