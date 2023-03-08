using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    GameObject tentacle;
    GlobalVars globalVars;
    float maxLength;
    bool attacking;
    float timer;

    void Start()
    {
        globalVars = GameObject.FindObjectOfType<GlobalVars>();
        tentacle = transform.GetChild(2).gameObject;
        tentacle.SetActive(false);
        maxLength = tentacle.transform.localScale.y;
        attacking = false;
    }

    void Update()
    {
        if (attacking)
        {
            tentacle.transform.localScale += new Vector3(0, Time.deltaTime * 7, 0);
            if (tentacle.transform.localScale.y >= maxLength)
            {
                attacking = false;
                StartCoroutine(SetInactive(0.2f));
            }
        }
    }

    IEnumerator SetInactive(float time)
    {
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(time);
            tentacle.SetActive(false);
            yield break;
        }
    }

    public void Stab()
    {
        if (globalVars.tentacleAmmo <= 0 || attacking || tentacle.activeSelf) return;

        globalVars.tentacleAmmo--;
        tentacle.transform.localScale = new Vector3(tentacle.transform.localScale.x, 0, tentacle.transform.localScale.z);
        tentacle.SetActive(true);
        timer = 0;
        attacking = true;
    }
}