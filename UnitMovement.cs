using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Camera myCam;
    NavMeshAgent myAgent;
    public LayerMask ground;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); //novoooooooooo
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {

                myAgent.SetDestination(hit.point);
                
            }

            

        }

        //novooooooooooooo
        if (myAgent.velocity != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else if (myAgent.velocity == Vector3.zero)
        {
            animator.SetBool("isWalking", false);
            

        }
    }
}
