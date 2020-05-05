using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl2 : MonoBehaviour
{
    private float timer = 0;
    public float RunWaterTime = 20;
    GameObject water;

    void Start()
    {
        water = GameObject.Find("Obi Emitter");
        water.GetComponent<ObiEmitter>().speed = 0;
    }

    void Update()
    {
        if (timer >= 0) {
            water.GetComponent<ObiEmitter>().speed = 3;
            timer -= Time.deltaTime;
        }
        else
        {
            water.GetComponent<ObiEmitter>().speed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        timer = RunWaterTime;
        
    }
}
