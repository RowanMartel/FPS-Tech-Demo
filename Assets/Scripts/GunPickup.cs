using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public int gunID;
    GlobalVars globalVars;

    void Start()
    {
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        SetModelActive();
    }

    public void SwapGun()
    {
        Debug.Log("swapping gun");

        int tempID = gunID;
        gunID = globalVars.playerWeapon;
        globalVars.playerWeapon = tempID;

        SetModelActive();
    }

    void SetModelActive()
    {
        Debug.Log("setting models active/inactive");

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        if (gunID == 0)
            return;

        transform.GetChild(gunID - 1).gameObject.SetActive(true);

        Debug.Log("succesfully set a model active");
    }
}