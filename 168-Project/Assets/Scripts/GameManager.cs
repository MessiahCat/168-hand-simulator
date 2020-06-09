using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Obi;

public class GameManager : MonoBehaviour
{
    float waterTemp = 0;
    float hotWaterTemp = 0;
    float coldWaterTemp = 0;
    //bool handsTouched = false;
    public string resetButton;
    public float hotWaterMax = 50;
    public float coldWaterMax = -50;
    public float aimTemptop = 10;
    public float aimTempbot = 5;
    public bool hotWaterOn = false;
    public bool coldWaterOn = false;
    //public bool success = false;
    public float timer = 0;
    /*public GameObject leftHand;
    public GameObject rightHand;*/
    public GameObject WaterTempBar;
    GameObject water;
    
    // Start is called before the first frame update
    void Start()
    {
        water = GameObject.Find("Obi Emitter");
        water.GetComponent<ObiEmitter>().speed = 0;
        WaterTempBar.SetActive(false);
        //alltouched();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(resetButton)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
    /*public void waterTempCheck() 
    {
        if (!success) {
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
    }*/
    public float setWaterTemp() {
        waterTemp = hotWaterTemp + coldWaterTemp;
        return waterTemp;
    }

    /*void alltouched() {
        foreach (Transform child in leftHand.transform) {
            if (child.gameObject.GetComponent<Touched_Me>().touched)
            {
                handsTouched = true;
            }
            else {
                handsTouched = false;
                return;
            }
        }
        foreach (Transform child in rightHand.transform)
        {
            if (child.gameObject.GetComponent<Touched_Me>().touched)
            {
                handsTouched = true;
            }
            else {
                handsTouched = false;
                return;
            }
        }
    }*/

}
