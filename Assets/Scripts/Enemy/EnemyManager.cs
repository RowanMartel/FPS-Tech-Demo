using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum EnemyStates
    {
        Patrolling,
        Chasing,
        Searching,
        Attacking,
        Retreating,
        Dying,
        Dead
    }
}