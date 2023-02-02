using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject Item;
    public int maxItems;
    int index = 0;
    GameObject[] Items;

    private void Start()
    {
        Items = new GameObject[maxItems];

        for (int i = 0; i < maxItems; i++)
        {
            Items[i] = Instantiate(Item, transform);
            Items[i].SetActive(false);
            Debug.Log(Items[i]);
        }
    }

    public void SpawnItem()
    {
        Items[index].transform.position = transform.position;
        Items[index].GetComponent<Rigidbody>().Sleep();
        Items[index].SetActive(true);

        index++;
        if (index == maxItems)
            index = 0;
    }
}