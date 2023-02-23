using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform FirstPatrolPoint;
    NavMeshAgent agent;

    EnemyManager.EnemyStates state;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(FirstPatrolPoint.position);
        state = EnemyManager.EnemyStates.Patrolling;
    }

    public void ChangePatrolTarget(Vector3 newTarget)
    {
        if (state != EnemyManager.EnemyStates.Patrolling)
            return;

        agent.SetDestination(newTarget);
    }
}