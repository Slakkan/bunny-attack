using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float moveSpeed;
    private float moveRange;
    private float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        moveSpeed = controller.moveSpeed;
        moveRange = controller.moveRange;

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * moveInput);
        float xPos = transform.position.x;

        if (Mathf.Abs(xPos) > moveRange)
        {
            transform.position = new Vector3(Mathf.Sign(xPos) * moveRange, transform.position.y, transform.position.z);
        }
    }
}
