using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public string weaponName;
    EquipWeapon playerWeapon;

    private void Start()
    {
        ChangeModel();
    }

    public void Equip()
    {
        if (weaponName == "none")
            return;

        playerWeapon = GameObject.Find("PlayerCapsule").GetComponent<EquipWeapon>();
        string newWeapon = playerWeapon.Equip(weaponName);
        weaponName = newWeapon;
        ChangeModel();
    }

    void ChangeModel()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        switch (weaponName)
        {
            case "pistol":
                transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }
}