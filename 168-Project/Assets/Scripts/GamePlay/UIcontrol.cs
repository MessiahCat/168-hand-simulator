﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UIcontrol : MonoBehaviour
{
    #region constant
    GameObject blue;
    GameObject red;
    GameObject green;
    GameObject pointer;
    float redlength;
    float greenlength;
    float bluelength;
    float barlength;
    const float totallength = 900f;
    #endregion

    #region variable
    
    [SerializeField]
    public float currentTem;//need to be import from outside.
    public float botton;
    public float top;
    public float aimstart;
    public float aimend;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        blue = GameObject.Find("blue");
        red = GameObject.Find("red");
        green = GameObject.Find("green");
        pointer = GameObject.Find("Pointer");
        CaculateBRGandset();
    }

    // Update is called once per frame
    void Update()
    {
        PinterContr();
    }
    #region Functions
    private void CaculateBRGandset() 
    {
        float totalC = top - botton;
        float blueP = aimstart - botton;
        float greenP = aimend - aimstart;
        float redP = top - aimend;

        float redL = redP / totalC * totallength;
        float blueL = blueP / totalC * totallength;
        float greenL = greenP / totalC * totallength;
        
        blue.GetComponent<RectTransform>().sizeDelta = new Vector2(blueL, 30f);
        green.GetComponent<RectTransform>().localPosition = new Vector3(blue.GetComponent<RectTransform>().localPosition.x + blueL, blue.GetComponent<RectTransform>().localPosition.y, blue.GetComponent<RectTransform>().localPosition.z);
        green.GetComponent<RectTransform>().sizeDelta = new Vector2(greenL, 30f);
        red.GetComponent<RectTransform>().localPosition = new Vector3(green.GetComponent<RectTransform>().localPosition.x + greenL, green.GetComponent<RectTransform>().localPosition.y, green.GetComponent<RectTransform>().localPosition.z);
        red.GetComponent<RectTransform>().sizeDelta = new Vector2(redL, 30f);
    }

    private void PinterContr() 
    {
        pointer.GetComponent<RectTransform>().localPosition = new Vector3(blue.GetComponent<RectTransform>().localPosition.x+((currentTem-botton) / (top - botton)) * 900f, blue.GetComponent<RectTransform>().localPosition.y+5f);
    }
    #endregion
}
