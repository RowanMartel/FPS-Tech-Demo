using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObj : MonoBehaviour
{
    GameObject player;
    public GameObject obj;

    public bool ActivateSetObjActive;
    public bool ActivateSetObjInactive;
    public bool ActivateToggleObjActive;

    public void Activate()
    {
        if (ActivateSetObjActive)
            SetObjActive();
        if (ActivateSetObjInactive)
            SetObjInactive();
        if (ActivateToggleObjActive)
            ToggleObjActive();
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
}