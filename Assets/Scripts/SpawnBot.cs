using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBot : MonoBehaviour
{
    public GameObject bot;
    private Vector2 randVector;
    public GameObject StartButton;

    public void Spawn_bot()
    {
        for (int i = 0; i < 1; i++)
        {
            randVector.Set(Random.Range(-99.5f, 99.5f), Random.Range(-99.5f, 99.5f));
            Instantiate(bot, randVector, Quaternion.identity);
            StartButton.SetActive(false);
        }
    }

    
}
