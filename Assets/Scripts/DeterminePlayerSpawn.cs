using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminePlayerSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerPrefab;
    GlobalVars vars;

    void Start()
    {
        vars = GameObject.FindObjectOfType<GlobalVars>();
        vars.Player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}