using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreInteractColliders : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(7, 3);
    }
}