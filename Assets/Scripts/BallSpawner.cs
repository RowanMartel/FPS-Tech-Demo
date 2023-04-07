using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject Ball;
    public int maxBalls;
    int index = 0;
    GameObject[] Balls;
    GlobalVars globalVars;

    private void Start()
    {
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
        Balls = new GameObject[maxBalls];

        for (int i = 0; i < maxBalls; i++)
        {
            Balls[i] = Instantiate(Ball);
            Balls[i].SetActive(false);
        }
    }

    public void SpawnItem()
    {
        if (globalVars.ballAmmo <= 0)
            return;

        Balls[index].SetActive(true);
        Balls[index].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane * 10));
        Balls[index].GetComponent<MetalBall>().Reset();

        index++;
        if (index == maxBalls)
            index = 0;

        globalVars.ballAmmo--;
    }
}