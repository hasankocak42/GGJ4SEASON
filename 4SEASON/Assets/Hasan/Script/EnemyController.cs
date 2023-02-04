using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public float speed = 10f;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, FindNearestRoot().transform.position) < 2f)
        {
            agent.isStopped = true;
            Attack();
        }else
        {
            agent.isStopped = false;
            //Buraya yürüme animasyon için gerekli saðlamalar yapýlýr.
            agent.SetDestination(FindNearestRoot().transform.position);
           // agent.destination = FindNearestRoot().transform.position;
        }

        
    }

    public GameObject FindNearestRoot()
    {
        GameObject nearestRoot = null;
        float closestDistance = Mathf.Infinity;

        GameObject[] roots = GameObject.FindGameObjectsWithTag("Root");
        foreach (GameObject root in roots)
        {
            float distance = Vector3.Distance(transform.position, root.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestRoot = root;
            }
        }
        return nearestRoot;
    }

    private void Attack()
    {
        //burada attack animasyonu yapýlýr.
    }
}
