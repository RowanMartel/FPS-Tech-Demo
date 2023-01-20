using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TPPoint;
    public bool KillZone;
    bool Teleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            if (!KillZone)
            {
                if (Teleporting)
                {
                    Teleporting = false;
                    return;
                }
                Teleporting = true;
            }

            other.transform.rotation = TPPoint.transform.rotation;
            other.GetComponentInParent<CharacterController>().Move(TPPoint.position - new Vector3(0, 0.906318f, 0) - GameObject.Find("PlayerCapsule").transform.position);
            other.GetComponentInParent<CharacterController>().SimpleMove(Vector3.zero);
        }
    }
}