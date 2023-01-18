using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObj : MonoBehaviour
{
    GameObject player;

    public bool RotatePlayerToggle;
    public float RotatePlayerAmount;
    public float RotatePlayerDegreesPerSec;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Activate()
    {
        if (RotatePlayerToggle)
            RotatePlayer();
    }

    IEnumerator RotatePlayer()
    {
        float elapsed = 0;

        while (player.transform.eulerAngles.y < RotatePlayerAmount)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion.Euler(transform.rotation.x, 345f, tramsform.rotation.z), Time.deltaTime * speed);
            elapsed += Time.deltaTime * RotatePlayerDegreesPerSec / 60;
            transform.Rotate(0, elapsed, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}