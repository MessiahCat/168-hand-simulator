using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger_move : MonoBehaviour
{
    public string key;
    public string FreezeKey;
   /* public GameObject Finger_base;
    public GameObject Finger_1;
    public GameObject Finger_2;*/
    public GameObject Finger_3;
    public float moveSpeed = 1f;
    public float rotationAngle = 90f;
    private bool frozen = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(FreezeKey) && !frozen) {
            Finger_3.GetComponent<Rigidbody>().freezeRotation = true;
            frozen = true;
        }
        else if (Input.GetKeyDown(FreezeKey) && frozen)
        {
            Finger_3.GetComponent<Rigidbody>().freezeRotation = false;
            frozen = false;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(key))
        {
            Finger_3.GetComponent<Rigidbody>().AddForce(0, moveSpeed, 0, ForceMode.Force);
            //Finger_3.transform.Rotate(new Vector3(rotationAngle, 0, 0) * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(key))
        {
            Finger_3.GetComponent<Rigidbody>().AddForce(0, -moveSpeed, 0, ForceMode.Force);
            //Finger_3.transform.Rotate(new Vector3(rotationAngle, 0, 0) * Time.deltaTime * moveSpeed);
        }
    }
}
