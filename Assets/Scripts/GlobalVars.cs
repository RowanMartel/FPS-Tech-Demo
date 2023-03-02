using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public bool teleporting;

    private int weaponHidden;
    public int playerWeapon
    {
        get { return weaponHidden; }
        set
        { 
            weaponHidden = value;
            gunManager.ChangeModel();
        }
    }

    public int keys;

    public Vector3 PlayerPos;

    public bool playerDeadHidden;
    public bool playerDead
    {
        get { return playerDeadHidden; }
        set 
        {
            playerDeadHidden = value;
            StartCoroutine(SetPlayerAlive(1));
        }
    }

    // ammo
    public int rodAmmo;
    public int rodAmmoMax;

    GunManager gunManager;

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
    }

    public bool KeyCheck()
    {
        if (keys <= 0)
            return false;
        else
        {
            keys--;
            return true;
        }
    }

    private IEnumerator SetPlayerAlive(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            playerDead = false;
        }
    }
}