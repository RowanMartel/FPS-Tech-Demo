using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3 StartPoint = new Vector3();
    Vector3 EndPoint = new Vector3();

    Transform platform;

    public float speed;
    public bool oneWay;
    public bool playerTriggered;
    public bool returnBySelf;

    bool movingTo = false;
    bool movingBack = false;

    void Start()
    {
        EndPoint = transform.GetChild(1).position;
        platform = transform.GetChild(0);
        StartPoint = platform.position;

        if (!playerTriggered)
            StartMove();
    }

    void Update()
    {
        if (movingTo)
        {
            platform.position = Vector3.MoveTowards(platform.position, EndPoint, speed * Time.deltaTime);
            if (platform.position == EndPoint)
            {
                movingTo = false;
                if ((!oneWay && !playerTriggered) || returnBySelf)
                    StartMove();
            }
        }
        else if (movingBack)
        {
            platform.position = Vector3.MoveTowards(platform.position, StartPoint, speed * Time.deltaTime);
            if (platform.position == StartPoint)
            {
                movingBack = false;
                if (!playerTriggered)
                    StartMove();
            }
        }
        else
            return;
    }

    void StartMove()
    {
        if (platform.position == StartPoint)
        {
            movingTo = true;
        }
        else if (platform.position == EndPoint)
        {
            if (oneWay)
                return;
            movingBack = true;
        }
        else
            return;
    }

    public void Parent(Collider other)
    {
        if (!playerTriggered)
            return;
        other.transform.root.SetParent(platform, true);
        if (movingTo || movingBack)
            return;
        StartMove();
    }
    public void UnParent(Collider other)
    {
        if (!playerTriggered)
            return;
        other.transform.parent.SetParent(null, true);
        if (movingTo || movingBack)
            return;
        StartMove();
    }
}