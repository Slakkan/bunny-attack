using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAttack : MonoBehaviour
{
    Transform currentTarget;
    [SerializeField] private Animator animator;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            animator.SetBool("isKicking", true);
            currentTarget = collision.transform;
        }
    }


    void Attack()
    {
        if(currentTarget != null)
        {
            WallStatus wallStatus = currentTarget.GetComponent<WallStatus>();
            if(wallStatus.status == Status.broken)
            {
                animator.SetBool("isKicking", false);
            }
            wallStatus.Damage();

        }
    }
}
