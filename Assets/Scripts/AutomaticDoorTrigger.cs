using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorTrigger : MonoBehaviour
{
    public DoorOpen doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            doorOpen.open = true;
            doorOpen.close = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            doorOpen.open = false;
            doorOpen.close = true;
        }
    }
}