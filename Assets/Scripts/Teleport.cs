using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TPPoint;
    public bool KillZone;
    GlobalVars globalVars;
    public bool rotate;
    DeterminePlayerSpawn playerSpawn;

    private void Start()
    {
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        globalVars.teleporting = false;
        playerSpawn = GameObject.Find("EventManager").GetComponent<DeterminePlayerSpawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            CharacterController CharController = other.GetComponentInParent<CharacterController>();

            if (!KillZone)
            {
                if (globalVars.teleporting)
                {
                    globalVars.teleporting = false;
                    return;
                }
                globalVars.teleporting = true;
            }
            else
            {
                TPPoint = playerSpawn.spawnPoint;
            }

            if (rotate)
                other.transform.rotation = TPPoint.transform.rotation;

            other.GetComponentInChildren<CapsuleCollider>().enabled = false;
            Physics.IgnoreLayerCollision(7, 0, true);


            CharController.Move(TPPoint.position - new Vector3(0, 0.906318f, 0) - GameObject.Find("PlayerCapsule").transform.position);
            CharController.SimpleMove(Vector3.zero);

            other.GetComponentInChildren<CapsuleCollider>().enabled = true;
            Physics.IgnoreLayerCollision(7, 0, false);
        }
    }
}