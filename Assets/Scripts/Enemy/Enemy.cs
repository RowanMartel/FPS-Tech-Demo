using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    const int STARTCHASERANGE = 4;
    const float ATTACKRANGE = 1.5f;
    const int CHASERANGE = 11;

    public Transform[] PatrolPoints;
    int CurrentPatrolPoint;

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
            timer = 0;
            PatrolToRetreat = false;
            PlayerHit = false;
        }
    }
    
    GlobalVars globalVars;

    float timer;
    float distance;

    public bool PlayerHit;
    bool PatrolToRetreat;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        AttackHitbox = transform.GetChild(0).gameObject;
        PatrolToRetreat = false;
        PlayerHit = false;
        CurrentPatrolPoint = 0;
        State = EnemyManager.EnemyStates.Patrolling;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, globalVars.PlayerPos);

        switch (State)
        {
            case EnemyManager.EnemyStates.Patrolling:
                Patrol();
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
                Retreat();
                break;
        }
    }

    void Patrol()
    {
        if (distance <= STARTCHASERANGE)
            State = EnemyManager.EnemyStates.Chasing;

        agent.SetDestination(PatrolPoints[CurrentPatrolPoint].position);
    }

    void Retreat()
    {
        if (distance <= STARTCHASERANGE)
            State = EnemyManager.EnemyStates.Chasing;

        agent.SetDestination(PatrolPoints[0].position);

        if (PatrolToRetreat)
            State = EnemyManager.EnemyStates.Patrolling;
    }

    void Chase()
    {
        if (distance <= ATTACKRANGE)
            State = EnemyManager.EnemyStates.Attacking;

        if (distance >= CHASERANGE)
            State = EnemyManager.EnemyStates.Searching;

        agent.SetDestination(globalVars.PlayerPos);

        if (globalVars.playerDead)
            State = EnemyManager.EnemyStates.Retreating;
    }

    void Search()
    {
        if (distance <= CHASERANGE)
            State = EnemyManager.EnemyStates.Chasing;

        timer += Time.deltaTime;
        if (timer >= 15)
            State = EnemyManager.EnemyStates.Retreating;
    }

    void Attack()
    {
        if (timer == 0)
            agent.SetDestination(transform.position);

        if (distance >= ATTACKRANGE)
            State = EnemyManager.EnemyStates.Chasing;

        timer += Time.deltaTime;
        if (timer >= 0.5f)
            AttackHitbox.SetActive(true);

        if (globalVars.playerDead)
            State = EnemyManager.EnemyStates.Retreating;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PatrolPoint")
        {
            CurrentPatrolPoint++;
            PatrolToRetreat = true;
            if (CurrentPatrolPoint >= PatrolPoints.Length)
                CurrentPatrolPoint = 0;
        }
    }
}