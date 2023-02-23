using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public Transform RedirectPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy")
            return;
        other.gameObject.GetComponent<Enemy>().ChangePatrolTarget(RedirectPoint.position);
    }
}