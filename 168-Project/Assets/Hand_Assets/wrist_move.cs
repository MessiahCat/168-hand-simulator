using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrist_move : MonoBehaviour
{

    public string rotateLeft;
    public string moveForward;
    public string moveRight;
    public string moveUp;
    public float moveSpeed = 1f;
    public float rotationAngle = 90f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(rotateLeft))
        {
            transform.Rotate(new Vector3(0, 0, -rotationAngle) * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(moveForward))
        {
            transform.position -= new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(moveRight))
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(moveUp))
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(rotateLeft)) {
            transform.Rotate(new Vector3(0, 0, rotationAngle) * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(moveForward))
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(moveRight))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(moveUp))
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }
}
