using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnStart;
    public float spawnInterval;   
    public GameObject bunnyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnStart, spawnInterval);
    }

    void Spawn()
    {
        Instantiate(bunnyPrefab, transform.position, bunnyPrefab.transform.rotation);
    }
}
