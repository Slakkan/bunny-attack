using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveInput;
    public float moveSpeed = 10;
    public float moveRange = 10;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * moveInput);
        float xPos = transform.position.x;

        if (Mathf.Abs(xPos) > moveRange)
        {
            transform.position = new Vector3(Mathf.Sign(xPos) * moveRange, transform.position.y, transform.position.z);
        }
        if(moveInput != 0)
        {
            animator.SetBool("Run", true);
        } else
        {
            animator.SetBool("Run", false);
        }
    }
}
