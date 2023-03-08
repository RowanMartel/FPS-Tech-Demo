using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    [System.NonSerialized]
    public GameObject Player;

    [System.NonSerialized]
    public bool teleporting;

    [System.NonSerialized]
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

    [System.NonSerialized]
    public int keys;

    [System.NonSerialized]
    public Vector3 PlayerPos;

    [System.NonSerialized]
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
    public int tentacleAmmo;
    public int tentacleAmmoMax;

    GunManager gunManager;

    [System.NonSerialized]
    public int kills;

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
        kills = 0;
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