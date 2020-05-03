using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class TestSinkMove : MonoBehaviour
{
    GameObject sink;
    [SerializeField]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        sink = GameObject.Find("Sink");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            sink.GetComponent<Transform>().position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.X))
        {
            sink.GetComponent<Transform>().position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
