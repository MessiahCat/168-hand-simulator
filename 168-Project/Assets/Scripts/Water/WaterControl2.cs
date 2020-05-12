using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl2 : MonoBehaviour
{
    GameManager GM;
    public int type = 0;
    float rotation;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        rotation = gameObject.transform.rotation.y;
        if (rotation < 0)
        {
            if (!GM.waterOn) {
                GM.turnOnWater();
                GM.waterOn = true;
            }

            GM.addHotWater(-rotation);
        }
        else
        {
            if (!GM.waterOn)
            {
                GM.turnOffWater();
                GM.waterOn = false;
            }
        }
    }
}
