using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [Tooltip("0: pistol")]
    public int type;
    PlayerWeapon player;

    void Start()
    {
        player = FindObjectOfType<PlayerWeapon>();
        ChangePickup();
    }

    public void Activate()
    {
        int tempType = type;
        type = player.weapon;
        player.weapon = tempType;
        ChangePickup();
    }

    void ChangePickup()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        transform.GetChild(type).gameObject.SetActive(true);
    }
}