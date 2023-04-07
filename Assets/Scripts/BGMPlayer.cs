using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    AudioSource BGM;

    void Start()
    {
        BGM = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!BGM.isPlaying)
            BGM.Play();
    }
}