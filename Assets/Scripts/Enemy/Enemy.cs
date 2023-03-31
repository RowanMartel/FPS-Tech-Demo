using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    const int STARTCHASERANGE = 7;
    const float ATTACKRANGE = 1.5f;
    const int CHASERANGE = 11;

    public Transform[] PatrolPoints;
    int CurrentPatrolPoint;

    [SerializeField]
    Material PatrolMat;
    [SerializeField]
    Material ChaseMat;
    [SerializeField]
    Material AttackMat;
    [SerializeField]
    Material SearchMat;
    [SerializeField]
    Material RetreatMat;
    [SerializeField]
    Material DyingMat;
    [SerializeField]
    AudioClip attentionNoise;
    [SerializeField]
    AudioClip dyingNoise;

    GameObject AttackHitbox;

    AudioSource audioSource;

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
            RetreatToPatrol = false;
            PlayerHit = false;
            switch (State)
            {
                case EnemyManager.EnemyStates.Dead:
                    gameObject.SetActive(false);
                    break;
                case EnemyManager.EnemyStates.Dying:
                    globalVars.kills++;
                    audioSource.PlayOneShot(dyingNoise);
                    break;
                case EnemyManager.EnemyStates.Chasing:
                    audioSource.PlayOneShot(attentionNoise);
                    break;
            }
        }
    }
    
    GlobalVars globalVars;

    float timer;
    float distance;

    public bool PlayerHit;
    bool RetreatToPatrol;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        AttackHitbox = transform.GetChild(0).gameObject;
        RetreatToPatrol = false;
        PlayerHit = false;
        CurrentPatrolPoint = 0;
        State = EnemyManager.EnemyStates.Patrolling;
        audioSource = GetComponent<AudioSource>();
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
            case EnemyManager.EnemyStates.Dying:
                Dying();
                break;
        }
    }

    void Dying()
    {
        transform.localScale -= new Vector3(Time.deltaTime * 5, Time.deltaTime * 5, Time.deltaTime * 5);
        if (transform.localScale.x <= 0)
        {
            State = EnemyManager.EnemyStates.Dead;
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

        if (RetreatToPatrol)
            State = EnemyManager.EnemyStates.Patrolling;
    }

    void Chase()
    {
        if (distance <= ATTACKRANGE)
            State = EnemyManager.EnemyStates.Attacking;

        if (distance >= CHASERANGE)
            State = EnemyManager.EnemyStates.Searching;

        agent.SetDestination(globalVars.PlayerPos);

        if (globalVars.PlayerDead)
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

        if (globalVars.PlayerDead)
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
            case EnemyManager.EnemyStates.Dying:
                GetComponent<Renderer>().material = DyingMat;
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PatrolPoint")
        {
            CurrentPatrolPoint++;
            RetreatToPatrol = true;
            if (CurrentPatrolPoint >= PatrolPoints.Length)
                CurrentPatrolPoint = 0;
            if (State == EnemyManager.EnemyStates.Retreating)
                for (int i = 0; i < PatrolPoints.Length; i++)
                    if (other.transform == PatrolPoints[i])
                        CurrentPatrolPoint = i + 1;
        }
        else if (other.CompareTag("PlayerAttack"))
        {
            Die();
        }
    }

    void Die()
    {
        if (State == EnemyManager.EnemyStates.Dying) return;
        State = EnemyManager.EnemyStates.Dying;
    }
}