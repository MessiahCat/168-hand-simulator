using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Obi;
using System.CodeDom;

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
    public GameObject Mainmenu;
    public GameObject ControlPannel;
    public GameObject PauseMenu;
    private bool gameon = false;
    GameObject water;
    
    // Start is called before the first frame update
    void Start()
    {
        water = GameObject.Find("Obi Emitter");
        water.GetComponent<ObiEmitter>().speed = 0;
        WaterTempBar.SetActive(false);
        ControlPannel.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 0;
        //alltouched();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(resetButton)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            ControlPannel.SetActive(true);
            PauseMenu.SetActive(false);
            Time.timeScale = 0;
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

    public void StartButton()
    {
        Time.timeScale = 1;
        Mainmenu.SetActive(false);
        PauseMenu.SetActive(true);
        gameon = true;
    }
    public void ControlButton() 
    {
        Mainmenu.SetActive(false);
        ControlPannel.SetActive(true);

    }

    public void ControlBackButton() 
    {
        if (gameon == false) 
        {
            ControlPannel.SetActive(false);
            Mainmenu.SetActive(true);
        }
        if (gameon == true) 
        {
            ControlPannel.SetActive(false);
            Time.timeScale = 1;
            PauseMenu.SetActive(true);
        }
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
