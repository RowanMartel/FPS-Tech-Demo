using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    bool growing;

    public void Reset()
    {
        growing = true;
        transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        transform.LookAt(Camera.main.transform);
        transform.Rotate(new Vector3(100, 0, 0));
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.SetParent(Camera.main.transform, true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            growing = false;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.SetParent(null, true);
        }
        if (!growing)
            return;

        if (transform.localScale.x >= 6)
            return;

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + Time.deltaTime * 3.5f, transform.localScale.z);
        transform.Translate(Vector3.down * Time.deltaTime * 1.75f);
    }
}