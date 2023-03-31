using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    bool growing;

    [SerializeField]
    Material wood;
    [SerializeField]
    Material woodEnd;
    [SerializeField]
    Material woodGrowing;
    [SerializeField]
    Material woodEndGrowing;

    Renderer rod;
    Renderer end1;
    Renderer end2;

    private void Start()
    {
        rod = GetComponent<Renderer>();
        end1 = rod.transform.GetChild(0).GetComponent<Renderer>();
        end2 = rod.transform.GetChild(1).GetComponent<Renderer>();
    }

    public void Reset()
    {
        growing = true;
        transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        transform.LookAt(Camera.main.transform);
        transform.Rotate(new Vector3(100, 0, 0));
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.SetParent(Camera.main.transform, true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rod.material = wood;
            end1.material = woodEnd;
            end2.material = woodEnd;
            growing = false;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.SetParent(null, true);
        }
        if (!growing)
            return;

        if (transform.localScale.x >= 6)
            return;

        rod.material = woodGrowing;
        end1.material = woodEndGrowing;
        end2.material = woodEndGrowing;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + Time.deltaTime * 3.5f, transform.localScale.z);
        transform.Translate(Vector3.down * Time.deltaTime * 1.75f);
    }
}