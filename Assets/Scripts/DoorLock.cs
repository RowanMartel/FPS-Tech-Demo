using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    DoorOpen door;
    bool unlocking = false;
    GlobalVars globalVars;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        door = transform.parent.GetComponentInChildren<DoorOpen>();
    }

    void Update()
    {
        if (!unlocking)
            return;


        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - Time.deltaTime);
        if (transform.localScale.z < 0.02f)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            unlocking = false;
            door.locked = false;
        }
    }

    public void Unlock()
    {
        if (!globalVars.KeyCheck() || unlocking)
            return;
        audioSource.Play();

        unlocking = true;
    }
}