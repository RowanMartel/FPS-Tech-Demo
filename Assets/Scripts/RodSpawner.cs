using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodSpawner : MonoBehaviour
{
    public GameObject Rod;
    public int maxRods;
    int index = 0;
    GameObject[] Rods;
    GlobalVars globalVars;

    private void Start()
    {
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        Rods = new GameObject[maxRods];

        for (int i = 0; i < maxRods; i++)
        {
            Rods[i] = Instantiate(Rod);
            Rods[i].SetActive(false);
        }
    }

    public void SpawnItem()
    {
        if (globalVars.rodAmmo <= 0)
            return;

        Rods[index].SetActive(true);
        Rods[index].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane * 10));
        Rods[index].GetComponent<Rod>().Reset();
        Rods[index].GetComponent<Rigidbody>().Sleep();

        index++;
        if (index == maxRods)
            index = 0;

        globalVars.rodAmmo--;
    }
}