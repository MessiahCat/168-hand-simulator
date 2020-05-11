using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl2 : MonoBehaviour
{
    GameManager GM;
    public int type = 0;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GM.turnOnWater();
        if (type == 0)
        {
            GM.addColdWater(10);
        }
        else {
            GM.addHotWater(10);
        }
    }
}
