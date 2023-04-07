using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ButtonObj : MonoBehaviour
{
    GameObject player;
    public GameObject obj;
    AudioSource audioSource;

    public bool ActivateSetObjActive;
    public bool ActivateSetObjInactive;
    public bool ActivateToggleObjActive;
    public bool ActivateSpawner;

    public Material ButtonMaterial;
    public Material PressedMaterial;

    private void Start()
    {
        GetComponent<Renderer>().material = ButtonMaterial;
        audioSource = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        GetComponent<Renderer>().material = PressedMaterial;

        if (ActivateSetObjActive)
            SetObjActive();
        if (ActivateSetObjInactive)
            SetObjInactive();
        if (ActivateToggleObjActive)
            ToggleObjActive();
        if (ActivateSpawner)
            Spawner();

        audioSource.Play();
        StartCoroutine("UnPress");
    }
    private IEnumerator UnPress()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material = ButtonMaterial;
    }

    public void SetObjInactive()
    {
        obj.gameObject.SetActive(false);
    }
    public void SetObjActive()
    {
        obj.gameObject.SetActive(true);
    }
    public void ToggleObjActive()
    {
        if (obj.activeInHierarchy)
            SetObjInactive();
        else
            SetObjActive();
    }
    public void Spawner()
    {
        obj.GetComponent<ItemSpawner>().SpawnItem();
    }
}