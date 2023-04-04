using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private DeterminePlayerSpawn playerSpawn;
    private Transform childTransform;
    private GameObject flag;
    private AudioSource source;

    private void Start()
    {
        playerSpawn = GameObject.Find("EventManager").GetComponent<DeterminePlayerSpawn>();
        childTransform = transform.GetChild(0);
        flag = transform.GetChild(1).GetChild(2).gameObject;
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        playerSpawn.spawnPoint = childTransform;
        if (!flag.activeSelf)
        {
            flag.SetActive(true);
            GetComponentInChildren<ParticleSystem>().Play();
            source.Play();
        }
    }

    private void Update()
    {
        if (playerSpawn.spawnPoint != childTransform)
            flag.SetActive(false);
    }
}