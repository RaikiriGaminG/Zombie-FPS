using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    NavMeshAgent NMAgent;
    public Transform Target;
    public float DistanceVariable = 15f;
    public float AttackVariable = 5f;
    public enum AIState {IDLE, CHASE, ATTACK}
    public AIState aistate = AIState.IDLE;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Think()
    {
        while (true)
        {
            switch (aistate)
            {
                case AIState.IDLE:
                    float Dist = Vector3.Distance(Target.position, transform.position);
                    if (Dist < DistanceVariable)
                    {
                        aistate = AIState.CHASE;
                        animator.SetBool("Chasing", true);
                    }
                    NMAgent.SetDestination(transform.position);
                    break;
                case AIState.CHASE:
                    Dist = Vector3.Distance(Target.position, transform.position);
                    if (Dist > DistanceVariable)
                    {
                        aistate = AIState.IDLE;
                        animator.SetBool("Chasing", false);
                    }
                    if (Dist < AttackVariable)
                    {
                        aistate = AIState.ATTACK;
                        animator.SetBool("Attacking", true);
                    }
                    NMAgent.SetDestination(Target.position);
                    break;
                case AIState.ATTACK:
                    NMAgent.SetDestination(transform.position);
                    Dist = Vector3.Distance(Target.position, transform.position);
                    if (Dist > AttackVariable)
                    {
                        aistate = AIState.CHASE;
                        animator.SetBool("Attacking", false);
                    }
                    break;
                default:
                    break;
                
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

}
