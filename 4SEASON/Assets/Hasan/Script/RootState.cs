using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RootState : MonoBehaviour
{


    private NavMeshAgent agent;
    public Transform RootTransform;

    float Healt;
    // Start is called before the first frame update
    void Start()
    {
        Healt = 100;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = RootTransform.position;
    }
}
