using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
            transform.GetComponentInParent<Enemy>().StartAttack();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerCapsule")
            transform.GetComponentInParent<Enemy>().StartChase();
    }
}