using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{
    public GameObject bot;
    private Vector2 randVector;

    void Awake()
    {
        for (int i = 0; i < 1; i++)
        {
            randVector.Set(Random.Range(-99.5f, 99.5f), Random.Range(-99.5f, 99.5f));
            Instantiate(bot, randVector, Quaternion.identity);
        }
    }
}
