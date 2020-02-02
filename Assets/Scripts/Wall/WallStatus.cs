using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    untouched,
    damaged,
    broken,
    destroyed
}

public class WallStatus : MonoBehaviour
{
    public Status status;

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
        ChangeScale();
        if (status == Status.destroyed)
        {
            Destroy(gameObject);
        }
    }


    void Repair()
    {
        if(status != 0 )
        {
            status--;
            ChangeScale();
        }        
    }

    void ChangeScale()//Temporal
    {
        switch (status)
        {
            case Status.untouched:
                transform.localScale = new Vector3(2, 2, 1);
                break;

            case Status.damaged:
                transform.localScale = new Vector3(2, 1.25f, 1);
                break;

            case Status.broken:
                transform.localScale = new Vector3(2, 0.75f, 1);
                break;
        }
    }
}
