using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    public GameObject creditsReference;
    public void Credits()
    {
        creditsReference.SetActive(true);
        gameObject.SetActive(false);
    }
}
