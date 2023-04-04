using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3 StartPoint = new Vector3();
    Vector3 EndPoint = new Vector3();

    Transform platform;
    AudioSource audioSource;

    [SerializeField]
    float speed;
    [SerializeField]
    float delay;
    [SerializeField]
    bool oneWay;
    [SerializeField]
    bool playerTriggered;
    [SerializeField]
    bool returnBySelf;

    bool movingTo = false;
    bool movingBack = false;

    float timer;

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        EndPoint = transform.GetChild(1).position;
        platform = transform.GetChild(0);
        StartPoint = platform.position;
        timer = 0;

        if (!playerTriggered)
            StartMove();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (movingTo)
        {
            if (timer < delay)
            {
                if (audioSource.isPlaying) audioSource.Stop();
                return;
            }

            if (!audioSource.isPlaying)
                audioSource.Play();
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
            if (timer < delay)
            {
                if (audioSource.isPlaying) audioSource.Stop();
                return;
            }

            if (!audioSource.isPlaying)
                audioSource.Play();
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
        timer = 0;
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
        other.transform.root.SetParent(platform, true);
        if (!playerTriggered)
            return;
        if (movingTo || movingBack)
            return;
        StartMove();
    }
    public void UnParent(Collider other)
    {
        other.transform.parent.SetParent(null, true);
        if (!playerTriggered)
            return;
        if (movingTo || movingBack)
            return;
        StartMove();
    }
}