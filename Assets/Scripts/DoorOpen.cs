using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float speed;

    [System.NonSerialized]
    public bool open;
    [System.NonSerialized]
    public bool close;

    public bool locked;

    Vector3 startPos;
    Vector3 endPos;

    AudioSource audioSource;

    private void Start()
    {
        open = false;
        close = false;

        startPos = transform.position;
        endPos = transform.position + new Vector3(0, 3, 0);

        if (locked)
            transform.parent.GetChild(2).gameObject.SetActive(true);

        audioSource = GetComponentInParent<AudioSource>();
    }
    private void Update()
    {
        if (locked)
        {
            audioSource.Stop();
            return;
        }
        if (open && transform.position.y < endPos.y)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        else if (close && transform.position.y > startPos.y)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        }
        else
        {
            audioSource.Stop();
        }   
    }
}