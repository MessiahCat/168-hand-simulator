using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Obi;
using System.CodeDom;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float waterTemp = 0;
    float hotWaterTemp = 0;
    float coldWaterTemp = 0;
    //bool handsTouched = false;
    public string resetButton;
    public float hotWaterMax ;
    public float coldWaterMax ;
    public float aimTemptop ;
    public float aimTempbot ;
    public bool hotWaterOn = false;
    public bool coldWaterOn = false;
    public bool success = false;
    public float timer = 0;
    /*public GameObject leftHand;
    public GameObject rightHand;*/
    public GameObject WaterTempBar;
    public GameObject Mainmenu;
    public GameObject ControlPannel;
    public GameObject PauseMenu;
    public GameObject Quest;
    private int leveler;
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
        Quest.SetActive(false);
        leveler = 0;
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
            Quest.SetActive(false);
            Time.timeScale = 0;
        }
        GamePlay();
    }


    private void GamePlay() 
    {
        if (leveler == 0)
        {
            Quest.GetComponent<Text>().text = "Quest1:\nopen the water";
            if (water.GetComponent<ObiEmitter>().speed != 0)
            {
                leveler++;
            }
        }
        else if (leveler == 1)
        {
            Quest.GetComponent<Text>().text = "Quest2:\nAddjust temperture arrow to the green area. \nHold for 3 sec";
            Debug.Log(waterTemp);
            if (success)
            {
                leveler++;
            }
        }
        else 
        {
            Quest.GetComponent<Text>().text = "All level passed";
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
    public void waterTempCheck() 
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
    }
    public float setWaterTemp() {
        waterTemp = hotWaterTemp + coldWaterTemp;
        return waterTemp;
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        Mainmenu.SetActive(false);
        PauseMenu.SetActive(true);
        Quest.SetActive(true);
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
            Quest.SetActive(true);
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
