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
}