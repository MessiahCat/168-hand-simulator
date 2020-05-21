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
    public float aimTemptop = 10;
    public float aimTempbot = 5;
    public bool hotWaterOn = false;
    public bool coldWaterOn = false;
    public bool success = false;
    public float timer = 0;
    public GameObject WaterTempBar;
    GameObject water;
    
    // Start is called before the first frame update
    void Start()
    {
        water = GameObject.Find("Obi Emitter");
        water.GetComponent<ObiEmitter>().speed = 0;
        WaterTempBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        waterTemp = hotWaterTemp + coldWaterTemp;
        waterTempCheck();
    }

    public void turnOnWater() {
        if (hotWaterOn || coldWaterOn) {
            water.GetComponent<ObiEmitter>().speed = 1;
            WaterTempBar.SetActive(true);
        }
    }

    public void turnOffWater() {
        if (!hotWaterOn && !coldWaterOn) {
            water.GetComponent<ObiEmitter>().speed = 0;
            WaterTempBar.SetActive(false);
        }
        
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
    public void waterTempCheck() 
    {
        if (waterTemp >= aimTempbot && waterTemp <= aimTemptop)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                success = true;
            }
        }
        else 
        {
            timer = 0;
        }
    }
    public float tempCheck() {
        return waterTemp;
    }
}
