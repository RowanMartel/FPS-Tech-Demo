using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    RodSpawner rodSpawner;

    private void Start()
    {
        rodSpawner = GameObject.FindObjectOfType<RodSpawner>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attempting to call spawnitem");
            rodSpawner.SpawnItem();
        }
    }
}