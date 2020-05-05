using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger_move : MonoBehaviour
{
    public string key;
    public GameObject Finger_3;
    public float moveSpeed = 1f;
    public float rotationAngle = 90f;
    public int Hand = 0;
    void Update()
    {
        if (Hand == 1)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(key))
            {
                Finger_3.GetComponent<Rigidbody>().AddForce(0, moveSpeed, 0, ForceMode.Force);
            }
            else if (Input.GetKey(key))
            {
                Finger_3.GetComponent<Rigidbody>().AddForce(0, -moveSpeed, 0, ForceMode.Force);
            }
        }
        else {
            if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(key))
            {
                Finger_3.GetComponent<Rigidbody>().AddForce(0, moveSpeed, 0, ForceMode.Force);
            }
            else if (Input.GetKey(key))
            {
                Finger_3.GetComponent<Rigidbody>().AddForce(0, -moveSpeed, 0, ForceMode.Force);
            }
        }
    }
}
