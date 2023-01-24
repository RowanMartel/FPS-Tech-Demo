using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public string currentWeapon = "none";

    public string Equip(string newWeapon)
    {
        string prevWeapon = currentWeapon;
        currentWeapon = newWeapon;
        ChangeWeapon();
        return prevWeapon;
    }
    void ChangeWeapon()
    {
        for (int i = 0; i < transform.GetChild(0).GetChild(0).childCount; i++)
            transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);

        switch (currentWeapon)
        {
            case "pistol":
                transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
                break;
        }
    }
}