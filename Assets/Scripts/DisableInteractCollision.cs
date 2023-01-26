using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInteractCollision : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(3, 7);
    }
}