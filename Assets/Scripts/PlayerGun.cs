using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    RodSpawner rodSpawner;
    Tentacle tentacle;
    GlobalVars globalVars;

    private void Start()
    {
        rodSpawner = GameObject.FindObjectOfType<RodSpawner>();
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        tentacle = GameObject.FindObjectOfType<Tentacle>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (globalVars.playerWeapon)
            {
                case 1:
                    rodSpawner.SpawnItem();
                    break;
                case 2:
                    globalVars.Player.GetComponentInChildren<Tentacle>().Stab();
                    break;
            }    
        }
    }
}