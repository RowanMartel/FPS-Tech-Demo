using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    GlobalVars globalVars;
    TMP_Text Text;

    void Start()
    {
        globalVars = GameObject.FindObjectOfType<GlobalVars>();
        Text = gameObject.GetComponent<TMP_Text>();
    }
    
    void Update()
    {
        Text.text = "Kills: " + globalVars.kills;
    }
}