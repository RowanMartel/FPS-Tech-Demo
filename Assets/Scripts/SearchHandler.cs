using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
            transform.GetComponentInParent<Enemy>().Find();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerCapsule")
            transform.GetComponentInParent<Enemy>().StartSearch();
    }
}