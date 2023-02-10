using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTrigger : MonoBehaviour
{
    MovingPlatform Platform;

    private void Start()
    {
        Platform = transform.parent.parent.gameObject.GetComponent<MovingPlatform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
            Platform.Parent(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
            Platform.UnParent(other);
    }
}