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

    GameObject AttackHitbox;

    NavMeshAgent agent;

    EnemyManager.EnemyStates state;
    EnemyManager.EnemyStates State
    {
        get { return state; }
        set 
        {
            state = value;
            ChangeColour();
            AttackHitbox.SetActive(false);
        }
    }
    
    GlobalVars globalVars;

    float timer;
    float distance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(FirstPatrolPoint.position);
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        AttackHitbox = transform.GetChild(0).gameObject;
        State = EnemyManager.EnemyStates.Patrolling;
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
                Attack();
                break;
            case EnemyManager.EnemyStates.Searching:
                Search();
                break;
            case EnemyManager.EnemyStates.Retreating:
                break;
        }

        distance = Vector3.Distance(transform.position, globalVars.PlayerPos);
        if (distance <= 11)
            Find();
        if (distance <= 4)
            StartChase();
        if (distance <= 1.5f)
            StartAttack();
        if (distance >= 11)
            StartSearch();
    }

    public void StopRetreat()
    {
        if (State == EnemyManager.EnemyStates.Retreating)
            State = EnemyManager.EnemyStates.Patrolling;
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

    void Attack()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
            AttackHitbox.SetActive(true);
    }

    public void StartChase()
    {
        if (distance <= 1.5f)
            return;
        if (State == EnemyManager.EnemyStates.Patrolling || State == EnemyManager.EnemyStates.Retreating || State == EnemyManager.EnemyStates.Attacking)
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
    }

    public void StartRetreat()
    {
        if (State == EnemyManager.EnemyStates.Searching || State == EnemyManager.EnemyStates.Attacking)
        {
            State = EnemyManager.EnemyStates.Retreating;
            agent.SetDestination(FirstPatrolPoint.position);
        }
    }

    public void StartAttack()
    {
        if (State != EnemyManager.EnemyStates.Chasing)
            return;
        State = EnemyManager.EnemyStates.Attacking;
        agent.SetDestination(transform.position);
        timer = 0;
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