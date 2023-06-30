using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform[] spawnpoints;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRocks", 3f, 10f);
    }
    private void SpawnRocks()
    {
        //starts at 0 and stops when reaches 4, so 4 loops in total
        for (int i = 0; i < 4; i++)
        {
            Vector3 randomPosition = spawnpoints[Random.Range(0, 3)].position;
            Instantiate(rockPrefab, randomPosition, Quaternion.identity);
        }
    }
}

