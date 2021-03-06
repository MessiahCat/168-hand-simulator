﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController3 : MonoBehaviour
{
    GameManager GM;
    public int type = 0;
    public float maxVal = 1.5f;
    public float minVal = .5f;
    public float offset = 0f;
    Rigidbody slider_body;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        slider_body = GetComponent<Rigidbody>();
        slider_body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxVal)
        {
            transform.position = new Vector3(transform.position.x, maxVal, transform.position.z);
        }
        if (type == 0)
        {
            if (transform.position.y > minVal && transform.position.y <= maxVal)
            {
                if (!GM.coldWaterOn)
                {
                    GM.coldWaterOn = true;
                    GM.turnOnWater();
                }
                GM.addColdWater(-50 * (transform.position.y - offset));
            }
            else if (transform.position.y < minVal)
            {
                GM.coldWaterOn = false;
                GM.turnOffWater();
                transform.position = new Vector3(transform.position.x, minVal, transform.position.z);
            }
        }
        else {
            if (transform.position.y > minVal && transform.position.y <= maxVal)
            {
                if (!GM.hotWaterOn)
                {
                    GM.hotWaterOn = true;
                    GM.turnOnWater(); 
                }
                GM.addHotWater(50 * (transform.position.y - offset));
            }
            else if (transform.position.y < minVal)
            {
                GM.hotWaterOn = false;
                GM.turnOffWater();
                transform.position = new Vector3(transform.position.x, minVal, transform.position.z);
            }
        }
    }
}
