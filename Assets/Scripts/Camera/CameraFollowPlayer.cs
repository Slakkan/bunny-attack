using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offset;
    [SerializeField] [Range(1, 5)] private float cameraSpeed = 1;
    private float initialFieldOfView = 60;
    private Vector3 previousPos;
    private float currentSpeed;
    [SerializeField] float fieldOfViewOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - transform.position;
        previousPos = transform.position;
}

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            currentSpeed = Vector3.Distance(transform.position, previousPos) / Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, player.transform.position - offset, cameraSpeed * Time.deltaTime);
            //PanOut();
            previousPos = transform.position;
        }
    }

    // TODO
    void PanOut()
    {
        float currentFieldOfView = Camera.main.fieldOfView;
        float updatedFieldOfView = Mathf.Lerp(currentFieldOfView, currentFieldOfView + (fieldOfViewOffset * currentSpeed), cameraSpeed * Time.deltaTime);
        Debug.Log(updatedFieldOfView);
        Camera.main.fieldOfView = updatedFieldOfView;
    }
}
