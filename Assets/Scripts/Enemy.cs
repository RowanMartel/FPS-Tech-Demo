using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform FirstPatrolPoint;

    NavMeshAgent agent;
    EnemyManager.EnemyStates state;
    GlobalVars globalVars;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(FirstPatrolPoint.position);
        state = EnemyManager.EnemyStates.Patrolling;
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
    }

    public void ChangePatrolTarget(Vector3 newTarget)
    {
        if (state == EnemyManager.EnemyStates.Patrolling || state == EnemyManager.EnemyStates.Retreating)
            agent.SetDestination(newTarget);
    }

    private void Update()
    {
        switch (state)
        {
            case EnemyManager.EnemyStates.Patrolling:
                break;
            case EnemyManager.EnemyStates.Chasing:
                Chase();
                break;
            case EnemyManager.EnemyStates.Attacking:
                break;
            case EnemyManager.EnemyStates.Searching:
                break;
            case EnemyManager.EnemyStates.Retreating:
                break;
        }
    }

    void Chase()
    {
        agent.SetDestination(globalVars.PlayerPos);
    }

    public void StartChase()
    {
        if (state == EnemyManager.EnemyStates.Patrolling || state == EnemyManager.EnemyStates.Searching || state == EnemyManager.EnemyStates.Retreating)
            state = EnemyManager.EnemyStates.Chasing;
    }
}