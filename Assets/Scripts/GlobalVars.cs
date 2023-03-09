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
    private int playerWeapon;
    public int PlayerWeapon
    {
        get { return playerWeapon; }
        set
        { 
            playerWeapon = value;
            gunManager.ChangeModel();
        }
    }

    [System.NonSerialized]
    public int keys;

    [System.NonSerialized]
    public Vector3 PlayerPos;

    [System.NonSerialized]
    public bool playerDead;
    public bool PlayerDead
    {
        get { return playerDead; }
        set 
        {
            playerDead = value;
            if (PlayerDead)
            {
                resetDeathCountdown = true;
                timer = 0;
            }
        }
    }
    bool resetDeathCountdown;
    float timer;

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
    private void Update()
    {
        if (resetDeathCountdown)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                PlayerDead = false;
                resetDeathCountdown = false;
                timer = 0;
            }
        }
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
            PlayerDead = false;
        }
    }
}