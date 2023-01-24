using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffInteractCollision : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(7, 3);
    }
}
