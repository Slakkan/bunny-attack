using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject loseCanvas;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bunny"))
        {
            loseCanvas.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
