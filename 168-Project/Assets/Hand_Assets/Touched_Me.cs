using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touched_Me : MonoBehaviour
{
    public bool touched = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            touched = true;
        }
    }
}
