using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger_move : MonoBehaviour
{
    public string key;
    public GameObject Finger_base;
    public GameObject Finger_1;
    public GameObject Finger_2;
    public GameObject Finger_3;
    public float moveSpeed = 1f;
    public float rotationAngle = 90f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            Finger_3.transform.Rotate(new Vector3(rotationAngle, 0, 0) * Time.deltaTime * moveSpeed);
        }
    }
}
