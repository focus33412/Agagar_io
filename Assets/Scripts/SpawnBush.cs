using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBush: MonoBehaviour
{
    public List<GameObject> bushs = new List<GameObject>();
    public GameObject Bush;
    private Vector2 randVector;

    void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            randVector.Set(Random.Range(-99.5f, 99.5f), Random.Range(-99.5f, 99.5f));
            GameObject axaxa = Instantiate(Bush, randVector, Quaternion.identity);
            bushs.Add(axaxa);
        }
    }
}
