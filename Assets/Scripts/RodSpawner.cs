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
            Rods[i] = Instantiate(Rod);
            Rods[i].SetActive(false);
        }

        Debug.Log(Rods[0]);
    }

    public void SpawnItem()
    {
        Rods[index].SetActive(true);
        Rods[index].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane * 10));
        Rods[index].GetComponent<Rigidbody>().Sleep();

        index++;
        if (index == maxRods)
            index = 0;
    }
}