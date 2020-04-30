using Obi;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaterConto : MonoBehaviour
{
    bool flu;
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
        if (Input.GetKeyDown(KeyCode.S) && flu == false)
        {
            Debug.Log(1);
            water.GetComponent<ObiEmitter>().speed = 3;
            flu = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && flu == true) 
        {
            Debug.Log(2);
            water.GetComponent<ObiEmitter>().speed = 0;
            flu = false;
        }
    }
}
