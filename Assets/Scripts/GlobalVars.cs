using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public bool teleporting;
    public int playerWeapon
    {
        get { return playerWeapon; }
        set
        { 
            playerWeapon = value;
            gunManager.ChangeModel();
        }
    }

    GunManager gunManager;

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
    }
}