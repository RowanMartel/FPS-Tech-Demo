using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodSpawner : MonoBehaviour
{
    public GameObject Rod;
    public int maxRods;
    int index = 0;
    GameObject[] Rods;

    private void Start()
    {
        Rods = new GameObject[maxRods];

        for (int i = 0; i < maxRods; i++)
        {
            Rods[i] = Instantiate(Rod, GameObject.FindGameObjectWithTag("MainCamera").transform);
            Rods[i].SetActive(false);
        }
    }

    public void SpawnItem()
    {
        Rods[index].transform.position = transform.position;
        Rods[index].GetComponent<Rigidbody>().Sleep();
        Rods[index].SetActive(true);

        index++;
        if (index == maxRods)
            index = 0;
    }
}