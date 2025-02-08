/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    
    Transform target;
    NavMeshAgent agent;


    //Codes like ENEMY CONTROLLER, ENEMY, ENEMY MANAGER ARE FROM THE BRACKEYS VIDEO FOR THE RPG
    
    void Start()
    {
        target = EnemyManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);  //tu ga prati

            if(distance <= agent.stoppingDistance)
            {
                //Attack the target

                //face the target 
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public Animator animator;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Find all the agents within the look radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, lookRadius);

        // Find the nearest agent
        Transform nearestAgent = null;
        float nearestDistance = Mathf.Infinity;
        foreach (Collider c in hitColliders)
        {
            if (c.CompareTag("Agent"))
            {
                float distance = Vector3.Distance(transform.position, c.transform.position);
                if (distance < nearestDistance)
                {
                    nearestAgent = c.transform;
                    nearestDistance = distance;
                }
            }
        }

        // If a nearest agent was found
        if (nearestAgent != null)
        {
            float distance = Vector3.Distance(nearestAgent.position, transform.position);

            if (distance <= lookRadius)
            {
                agent.SetDestination(nearestAgent.position);

                if (distance <= agent.stoppingDistance)
                {
                    //Attack the target
                    GetComponent<Rigidbody>().linearVelocity = Vector3.zero;//Novoooo

                    //face the target 
                    FaceTarget(nearestAgent);
                }
            }
        }

        if (agent.velocity != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else if (agent.velocity == Vector3.zero)
        {
            animator.SetBool("isWalking", false);
        }
    }

    

    void FaceTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}