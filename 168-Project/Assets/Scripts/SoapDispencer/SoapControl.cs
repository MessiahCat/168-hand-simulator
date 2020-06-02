using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class SoapControl : MonoBehaviour
{
    public float timeSoapDispence = 3f;
    public float movementTime = .5f;
    public float pumpSpeed = 1f;
    GameObject saop;
    float pumpingTimer = 0f;
    float movingTimer = 0f;
    Vector3 originalPosition;
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        saop = GameObject.Find("Obi soap");
        saop.GetComponent<ObiEmitter>().speed = 2;
        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingTimer >= 0)
        {
            movingTimer -= Time.deltaTime;
        }
        else {
            moveBack();
        }
        if (pumpingTimer >= 0)
        {
            pumpingTimer -= Time.deltaTime;
        }
        else {
            saop.GetComponent<ObiEmitter>().speed = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        pumpingTimer = timeSoapDispence;
        saop.GetComponent<ObiEmitter>().speed = 3;
    }

    void OnCollisionEnter(Collision collision)
    {
        movingTimer = movementTime;
    }

    void moveBack() {
        if (transform.position != originalPosition)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * pumpSpeed);
            transform.position = Vector3.Slerp(transform.position, originalPosition, Time.deltaTime * pumpSpeed);
        }
    }
}
