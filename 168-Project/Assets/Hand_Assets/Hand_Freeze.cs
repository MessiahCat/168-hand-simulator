using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Freeze : MonoBehaviour
{
    public string FreezeKey;
    public bool frozen = true;

    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(FreezeKey) && !frozen)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            }
            frozen = true;
        }
        else if (Input.GetKeyDown(FreezeKey) && frozen)
        {
            foreach (Transform child in transform) {
                child.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            }
            frozen = false;
        }
    }
}
