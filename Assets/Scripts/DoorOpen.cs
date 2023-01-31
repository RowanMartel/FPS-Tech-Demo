using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float openTime;
    float elapsedTime;

    public bool open;
    public bool close;

    private void Start()
    {
        open = false;
        close = false;
    }
    private void Update()
    {
        if (open && elapsedTime < openTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position += new Vector3(0, 0.5f / openTime / 60, 0);
        }
        else if (close && elapsedTime < openTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position += new Vector3(0, -0.5f / openTime / 60, 0);
        }
        if (elapsedTime >= openTime)
        {
            elapsedTime = 0;
            open = false;
            close = false;
        }
    }
}