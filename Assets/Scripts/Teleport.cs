using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TPPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.root.gameObject.GetComponentInChildren<CharacterController>().enabled = false;
            other.transform.root.position = TPPoint.position;
            other.transform.root.gameObject.GetComponentInChildren<CharacterController>().enabled = true;
        }
    }
}