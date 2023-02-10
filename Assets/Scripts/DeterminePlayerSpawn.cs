using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminePlayerSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerPrefab;

    void Start()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}