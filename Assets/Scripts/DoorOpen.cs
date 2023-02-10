using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float speed;

    public bool open;
    public bool close;
    public bool locked;

    Vector3 startPos;
    Vector3 endPos;

    private void Start()
    {
        open = false;
        close = false;

        startPos = transform.position;
        endPos = transform.position + new Vector3(0, 3, 0);

        if (locked)
            transform.parent.GetChild(2).gameObject.SetActive(true);
    }
    private void Update()
    {
        if (locked)
            return;
        if (open && transform.position.y < endPos.y)
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        else if (close && transform.position.y > startPos.y)
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
    }
}