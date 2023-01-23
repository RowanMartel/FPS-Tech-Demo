using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearMouse : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.visible = true;
        if (Input.GetMouseButton(0))
            Cursor.visible = false;
    }
}
