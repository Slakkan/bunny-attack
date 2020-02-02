using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWarning : MonoBehaviour
{
    public Canvas canvas;
    public float durationTime = 1;
    float activationTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((activationTime + durationTime) < Time.time && canvas.enabled)
        {
            canvas.enabled = false;
        }
    }

    public void Warn()
    {
        activationTime = Time.time;
        canvas.enabled = true;
    }
}
