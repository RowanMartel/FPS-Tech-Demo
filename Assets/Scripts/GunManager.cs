using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    GlobalVars globalVars;

    private void Start()
    {
        globalVars = FindObjectOfType<GlobalVars>();
    }

    void Update()
    {
        transform.position = FindObjectOfType<CharacterController>().transform.position + new Vector3(1, 0, 1);
    }

    public void ChangeModel()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        if (globalVars.playerWeapon == 0)
            return;

        transform.GetChild(globalVars.playerWeapon - 1).gameObject.SetActive(true);
    }
}