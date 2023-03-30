using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    GlobalVars globalVars;
    AudioSource audioSource;

    public int ammoType;
    public bool respawning;
    float timeSincePickup;
    bool collected = false;

    void Start()
    {
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        ShowModel();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!collected || !respawning)
        {
            timeSincePickup = 0;
            return;
        }

        timeSincePickup += Time.deltaTime;
        if (timeSincePickup >= 5)
        {
            collected = false;
            ShowModel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected)
            return;
        else if (other.gameObject.layer == 7)
            Pickup();
    }

    void Pickup()
    {
        audioSource.Play();
        collected = true;
        HideModel();

        switch (ammoType)
        {
            case 1:
                if (globalVars.rodAmmo == globalVars.rodAmmoMax)
                    return;
                globalVars.rodAmmo++;
                break;
            case 2:
                if (globalVars.tentacleAmmo == globalVars.tentacleAmmoMax)
                    return;
                globalVars.tentacleAmmo++;
                break;
        }
    }

    void ShowModel()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
        transform.GetChild(ammoType - 1).gameObject.SetActive(true);
    }
    void HideModel()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }
}