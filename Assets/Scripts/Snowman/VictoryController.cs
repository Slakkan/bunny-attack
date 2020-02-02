using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryController : MonoBehaviour
{
    public float time, timeInterval;
    public Text timerText, shadowTimerText;
    public GameObject victoryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = time.ToString();
        shadowTimerText.text = time.ToString();
        InvokeRepeating("DecressTime", timeInterval, timeInterval);
    }

    void DecressTime()
    {
        if(time > 0)
        {
            time -= timeInterval;
            timerText.text = time.ToString();
            shadowTimerText.text = time.ToString();
        }
        else
        {
            CancelInvoke();
            Time.timeScale = 0;
            victoryCanvas.SetActive(true);
        }
        
    }
}
