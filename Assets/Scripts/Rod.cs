using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    bool growing = true;

    void Update()
    {
        if (!Input.GetMouseButton(0))
            growing = false;
        if (!growing)
            return;

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + Time.deltaTime, transform.localScale.z);
    }
}