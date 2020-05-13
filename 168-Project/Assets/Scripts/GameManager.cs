using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class GameManager : MonoBehaviour
{
    float waterTemp = 0;
    float hotWaterTemp = 0;
    float coldWaterTemp = 0;
    public float hotWaterMax = 50;
    public float coldWaterMax = -50;
    public bool waterOn = false;
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
        waterTemp = hotWaterTemp + coldWaterTemp;
    }

    public void turnOnWater() {
        water.GetComponent<ObiEmitter>().speed = 1;
    }

    public void turnOffWater() {
        water.GetComponent<ObiEmitter>().speed = 0;
    }

    public void addHotWater(float tempurature) {
        if (waterTemp <= hotWaterMax) {
            hotWaterTemp = tempurature;
        }
    }

    public void addColdWater(float tempurature) {
        if (waterTemp >= coldWaterMax)
        {
            coldWaterTemp = tempurature;
        }
    }

    public float tempCheck() {
        return waterTemp;
    }
}
