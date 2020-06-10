using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Obi;
using System.CodeDom;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    float waterTemp = 0;
    float hotWaterTemp = 0;
    float coldWaterTemp = 0;
    bool handsTouched = false;
    public string resetButton;
    public float hotWaterMax ;
    public float coldWaterMax ;
    public float aimTemptop ;
    public float aimTempbot ;
    public bool hotWaterOn = false;
    public bool coldWaterOn = false;
    public bool success = false;
    private float timer = 0;
    public GameObject leftHand;
    public GameObject rightHand;
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
            Quest.GetComponent<Text>().text = "Quest 1:\nopen the water";
            if (water.GetComponent<ObiEmitter>().speed != 0)
            {
                leveler++;
            }
        }
        else if (leveler == 1)
        {
            Quest.GetComponent<Text>().text = "Quest 2:\nAddjust temperture arrow to the green area. \nHold for 3 sec";
            if (success)
            {
                leveler++;
            }
        }
        else if (leveler == 2)
        {
            float percent = CaculatePercentagewater();
            Quest.GetComponent<Text>().text = "Quest 3:\nNow wet your hand using the water.\n" + percent.ToString("f2") + "% Completed, 95% to pass.";
            if (percent >= 95f)
            {
                resethands();
                leveler++;
            }
        }
        else if (leveler == 3)
        {
            bool soap = touchedsoap();
            Quest.GetComponent<Text>().text = "Quest 4:\ndispense soap to your hand.\nDispenser is on the right of the sink.";
            if (soap)
            {
                resethands();
                leveler++;
            }
        }
        else if (leveler == 4) 
        {
            float percenthand = CaculatePercentage();
            Quest.GetComponent<Text>().text = "Quest 3:\nNow rub your hands\n" + percenthand.ToString("f2") + "% Completed, 95% to pass.";
            if (percenthand >= 95f) 
            {
                resethands();
                leveler++;
            }

        }
        else if (leveler == 5)
        {
            float percent = CaculatePercentagewater();
            Quest.GetComponent<Text>().text = "Quest 3:\nNow clean your hands with water\n" + percent.ToString("f2") + "% Completed, 95% to pass.";
            if (percent >= 95f)
            {
                resethands();
                leveler++;
            }
        }
        else
        {
            Quest.GetComponent<Text>().text = "All level passed";
        }
    }

    private float CaculatePercentagewater() 
    {
        float percent;
        float touched = 0;
        float total = 0;



        foreach (Transform child in leftHand.transform)
        {
            if (child.gameObject.GetComponent<Touched_Me>().touchedwater)
            {
                touched++;
            }
            total++;
        }
        foreach (Transform child in rightHand.transform)
        {
            if (child.gameObject.GetComponent<Touched_Me>().touchedwater)
            {
                touched++;
            }
            total++;
        }
        percent = touched / total * 100;
        return percent;
    }
    private float CaculatePercentage()
    {
        float percent;
        float touched = 0;
        float total = 0;

        

        foreach (Transform child in leftHand.transform) 
        {
            if (child.gameObject.GetComponent<Touched_Me>().touched)
            {
                touched++;
            }
            total++;
        }
        foreach (Transform child in rightHand.transform)
        {
            if (child.gameObject.GetComponent<Touched_Me>().touched)
            {
                touched++;
            }
            total++;
        }
        percent = touched / total*100;
        return percent;
    }

    private bool touchedsoap() 
    {
        foreach (Transform child in leftHand.transform) 
        {
            if (child.gameObject.GetComponent<Touched_Me>().touchedsoap) 
            {
                return true;
            }
        }
        foreach (Transform child in rightHand.transform)
        {
            if (child.gameObject.GetComponent<Touched_Me>().touchedsoap)
            {
                return true;
            }
        }
        return false;

    }

    private void resethands() 
    {
        foreach (Transform child in leftHand.transform) 
        {
            child.gameObject.GetComponent<Touched_Me>().touched = false;
            child.gameObject.GetComponent<Touched_Me>().touchedwater = false;
            child.gameObject.GetComponent<Touched_Me>().touchedsoap = false;
        }
        foreach (Transform child in rightHand.transform)
        {
            child.gameObject.GetComponent<Touched_Me>().touched = false;
            child.gameObject.GetComponent<Touched_Me>().touchedwater = false;
            child.gameObject.GetComponent<Touched_Me>().touchedsoap = false;
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



}
