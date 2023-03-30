using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorTrigger : MonoBehaviour
{
    public DoorOpen doorOpen;
    Collider colliderCharacter;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 11)
            colliderCharacter = other;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 11)
            colliderCharacter = null;
    }

    private void Update()
    {
        if (colliderCharacter)
        {
            doorOpen.open = true;
            doorOpen.close = false;
        }
        else
        {
            doorOpen.open = false;
            doorOpen.close = true;
        }
    }
}