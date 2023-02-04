using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject treePrefab;
    public Transform[] spawnPoints;
    public int counter = 0;
    private int spawnIndex = 0;

    private void Update()
    {
        GameObject[] Roots = GameObject.FindGameObjectsWithTag("Root");
        foreach (GameObject root in Roots)
        {
            if (root.transform.position == spawnPoints[spawnIndex].position)
            {
                Destroy(root);
                counter++;
                if (counter % 10 == 0)
                {
                    spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
                    Instantiate(treePrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
                }
            }
        }
    }
}
