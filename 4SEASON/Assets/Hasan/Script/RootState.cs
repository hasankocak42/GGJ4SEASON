using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RootState : MonoBehaviour
{


    private NavMeshAgent agent;
    private Transform RootTransform;

    public float Healt;
    // Start is called before the first frame update
    void Start()
    {
        RootTransform = GameObject.FindGameObjectWithTag("finish").transform;
        Healt = 100;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ÝsDead();
        agent.destination = RootTransform.position;
    }
    void ÝsDead()
    {
        if (Healt <= 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
