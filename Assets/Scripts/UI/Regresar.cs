using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regresar : MonoBehaviour
{
    public GameObject MenuReference;
    public void Credits()
    {
        MenuReference.SetActive(true);
        gameObject.SetActive(false);
    }
}
