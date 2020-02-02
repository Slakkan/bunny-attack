using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        timer.SetActive(true);
    }
}
