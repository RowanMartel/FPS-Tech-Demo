using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform FirstPatrolPoint;

    public Material PatrolMat;
    public Material ChaseMat;
    public Material AttackMat;
    public Material SearchMat;
    public Material RetreatMat;

    NavMeshAgent agent;

    EnemyManager.EnemyStates state;
    EnemyManager.EnemyStates State
    {
        get { return state; }
        set 
        {
            state = value;
            ChangeColour();
        }
    }
    
    GlobalVars globalVars;

    float timer;
    int searchState;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(FirstPatrolPoint.position);
        State = EnemyManager.EnemyStates.Patrolling;
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
    }

    public void ChangePatrolTarget(Vector3 newTarget)
    {
        if (State == EnemyManager.EnemyStates.Patrolling || State == EnemyManager.EnemyStates.Retreating)
            agent.SetDestination(newTarget);
    }

    private void Update()
    {
        switch (State)
        {
            case EnemyManager.EnemyStates.Patrolling:
                break;
            case EnemyManager.EnemyStates.Chasing:
                Chase();
                break;
            case EnemyManager.EnemyStates.Attacking:
                break;
            case EnemyManager.EnemyStates.Searching:
                Search();
                break;
            case EnemyManager.EnemyStates.Retreating:
                break;
        }
    }

    void Chase()
    {
        agent.SetDestination(globalVars.PlayerPos);
    }

    void Search()
    {
        timer += Time.deltaTime;
        if (timer >= 15)
            StartRetreat();
    }

    public void StartChase()
    {
        if (State == EnemyManager.EnemyStates.Patrolling || State == EnemyManager.EnemyStates.Retreating)
            State = EnemyManager.EnemyStates.Chasing;
    }

    public void Find()
    {
        if (State == EnemyManager.EnemyStates.Searching)
            State = EnemyManager.EnemyStates.Chasing;
    }

    public void StartSearch()
    {
        if (State != EnemyManager.EnemyStates.Chasing)
            return;
        State = EnemyManager.EnemyStates.Searching;
        timer = 0;
        searchState = 0;
    }

    public void StartRetreat()
    {
        if (State != EnemyManager.EnemyStates.Searching)
            return;
        state = EnemyManager.EnemyStates.Retreating;
        agent.SetDestination(FirstPatrolPoint.position);
    }

    void ChangeColour()
    {
        switch (State)
        {
            case EnemyManager.EnemyStates.Chasing:
                GetComponent<Renderer>().material = ChaseMat;
                break;
            case EnemyManager.EnemyStates.Retreating:
                GetComponent<Renderer>().material = RetreatMat;
                break;
            case EnemyManager.EnemyStates.Patrolling:
                GetComponent<Renderer>().material = PatrolMat;
                break;
            case EnemyManager.EnemyStates.Attacking:
                GetComponent<Renderer>().material = AttackMat;
                break;
            case EnemyManager.EnemyStates.Searching:
                GetComponent<Renderer>().material = SearchMat;
                break;
        }
    }
}