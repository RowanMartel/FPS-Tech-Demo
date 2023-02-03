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

    GunManager gunManager;

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
    }
}