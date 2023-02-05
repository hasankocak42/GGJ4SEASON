using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCreator : MonoBehaviour
{
    public GameObject rootPrefab;
    public Transform[] rootSpawnPoints;
    public float spawnTime = 1f;
    private int rootCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnRoot", spawnTime, spawnTime);
    }

    void SpawnRoot()
    {
        int randomIndex = Random.Range(0, rootSpawnPoints.Length);
        Instantiate(rootPrefab, rootSpawnPoints[randomIndex].position, Quaternion.identity);

        rootCount++;
        if (rootCount >= 50)
        {
            CancelInvoke("SpawnRoot");
        }
    }
}
