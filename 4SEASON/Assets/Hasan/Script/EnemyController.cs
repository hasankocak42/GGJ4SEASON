using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public float speed = 10f;
    private NavMeshAgent agent;
    private Animator anim;
    float timer;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        count = 0;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
            count++;
            Debug.Log(Vector3.Distance(transform.position, FindNearestRoot().transform.position));
        if (Vector3.Distance(transform.position, FindNearestRoot().transform.position) < 20f)
        {
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                agent.isStopped = true;
            Attack();
            anim.SetBool("Attack",false);
                timer = 0f;
            }
        }
        else
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
        anim.SetBool("Attack",true);
        FindNearestRoot().GetComponent<RootState>().Healt -= 25;
    }
}
