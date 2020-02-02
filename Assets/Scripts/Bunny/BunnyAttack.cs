using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAttack : MonoBehaviour
{
    int attacksBeforeRetreat = 2;
    public GameObject bunnyPrefab;
    BunnyMovement bunnyMovement;
    Transform currentTarget;
    [SerializeField] private Animator animator;

    private void Start()
    {
        bunnyMovement = bunnyPrefab.gameObject.GetComponent<BunnyMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!bunnyMovement.isRetrating && collision.gameObject.CompareTag("Wall"))
        {
            animator.SetBool("isKicking", true);
            currentTarget = collision.transform;
        }
    }


    void Attack()
    {
        if(!bunnyMovement.isRetrating && currentTarget != null)
        {
            WallStatus wallStatus = currentTarget.GetComponent<WallStatus>();
            if(wallStatus.status == Status.broken)
            {
                animator.SetBool("isKicking", false);
            }
            wallStatus.Damage();
            attacksBeforeRetreat -= 1;
            if(attacksBeforeRetreat == 0)
            {
                bunnyMovement.Retreat();
            }
        }
    }
}
