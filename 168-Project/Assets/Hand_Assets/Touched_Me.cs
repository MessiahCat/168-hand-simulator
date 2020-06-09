using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touched_Me : MonoBehaviour
{
    public bool touched = false;
    public bool touchedwater = false;
    public bool touchedsoap = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftHand" && gameObject.tag == "RightHand") 
        {
            touched = true;
        }
        if (collision.gameObject.tag == "RightHand" && gameObject.tag == "LeftHand")
        {
            touched = true;
        }
    }
}
