using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class GameManager : MonoBehaviour
{
    int waterTemp = 0;
    public int hotWaterMax = 50;
    public int coldWaterMax = -50;
    GameObject water;
    
    // Start is called before the first frame update
    void Start()
    {
        water = GameObject.Find("Obi Emitter");
        water.GetComponent<ObiEmitter>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOnWater() {
        water.GetComponent<ObiEmitter>().speed = 3;
    }

    public void turnOffWater() {
        water.GetComponent<ObiEmitter>().speed = 0;
    }

    public void addHotWater(int tempurature) {
        if (waterTemp <= hotWaterMax) {
            waterTemp += tempurature;
        }
    }

    public void addColdWater(int tempurature) {
        if (waterTemp >= coldWaterMax)
        {
            waterTemp += tempurature;
        }
    }

    public int tempCheck() {
        return waterTemp;
    }
}
