using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject eat;
    private Vector2 randVector;

    void Awake()
    {
        for (int i = 0; i < 5000; i++)
        {
            randVector.Set(Random.Range(-99.5f, 99.5f), Random.Range(-99.5f, 99.5f));
            Instantiate(eat, randVector, Quaternion.identity);
        }
    }
}
