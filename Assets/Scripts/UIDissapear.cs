using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDissapear : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}