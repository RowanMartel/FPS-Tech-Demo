using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    GlobalVars vars;
    public int ammoType;
    TMPro.TMP_Text Text;

    void Start()
    {
        vars = GameObject.FindObjectOfType<GlobalVars>();
        Text = gameObject.GetComponent<TMPro.TMP_Text>();
    }

    void Update()
    {
        switch (ammoType)
        {
            case 1:
                Text.SetText(vars.rodAmmo.ToString());
                break;
            case 2:
                Text.SetText(vars.tentacleAmmo.ToString());
                break;
            case 3:
                Text.SetText(vars.ballAmmo.ToString());
                break;
        }
    }
}