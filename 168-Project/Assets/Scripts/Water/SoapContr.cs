using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapContr : MonoBehaviour
{
    ObiEmitter soap;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        soap = GameObject.Find("soap").GetComponent<ObiEmitter>();
        soap.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            soap.speed = 4;
            timer = 0.2f;
        }

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0) 
        {
            soap.speed = 0;
        }
    }
}
