using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCreator : MonoBehaviour
{
    public GameObject bugPrefab;
    public Transform[] bugSpawnPoints;
    public float spawnTime = 2f;

    void Start()
    {
        InvokeRepeating("SpawnBug", spawnTime, spawnTime);
    }

    void SpawnBug()
    {
        int randomIndex = Random.Range(0, bugSpawnPoints.Length);
        Instantiate(bugPrefab, bugSpawnPoints[randomIndex].position, Quaternion.identity);
    }
}
