using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public int gunID;
    GlobalVars globalVars;
    AudioSource audioSource;

    void Start()
    {
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        SetModelActive();
        audioSource = GetComponent<AudioSource>();
    }

    public void SwapGun()
    {
        int tempID = gunID;
        gunID = globalVars.PlayerWeapon;
        globalVars.PlayerWeapon = tempID;
        audioSource.Play();

        SetModelActive();
    }

    void SetModelActive()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        if (gunID == 0)
            return;

        transform.GetChild(gunID - 1).gameObject.SetActive(true);
    }
}