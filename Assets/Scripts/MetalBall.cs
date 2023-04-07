using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBall : MonoBehaviour
{
    Rigidbody rb;

    public void Reset()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        transform.LookAt(Camera.main.transform);
        transform.Rotate(new Vector3(100, 0, 0));
        rb.Sleep();
        rb.AddRelativeForce(Vector3.down * 10000);
    }
}