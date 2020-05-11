using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRotation : MonoBehaviour
{
    float rotSpeed = 50;
    // Start is called before the first frame update
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        Vector3 rotationPoint = transform.position;
        transform.Rotate(Vector3.up, -rotX);
    }
}
