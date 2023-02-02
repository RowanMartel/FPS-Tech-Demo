using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            CastTriggerRay();
    }

    void CastTriggerRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.layer == 3)
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Button":
                        hit.collider.gameObject.GetComponent<ButtonObj>().Activate();
                        break;
                    case "Gun":
                        Debug.Log("gun detected");
                        hit.collider.gameObject.GetComponent<GunPickup>().SwapGun();
                        break;
                }
            }
        }
        else
            Debug.Log("");
    }
}