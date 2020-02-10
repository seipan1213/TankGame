using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siten : MonoBehaviour
{



    public float turnspeed = 4;

    // Use this for initialization
    void Start()
    {

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (Camera.main.transform.eulerAngles.x <= 20 && Camera.main.transform.eulerAngles.x >= 0 || Camera.main.transform.eulerAngles.x <= 360 && Camera.main.transform.eulerAngles.x >= 350)
        {
            transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * turnspeed);
        }
        else if (Camera.main.transform.eulerAngles.x > 20 && Camera.main.transform.eulerAngles.x < 180 && Input.GetAxis("Mouse Y") >= 0)
        {
            transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * turnspeed);
        }
        else if (Camera.main.transform.eulerAngles.x < 350 && Camera.main.transform.eulerAngles.x >= 180 && Input.GetAxis("Mouse Y") <= 0)
        {
            transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * turnspeed);
        }



        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * turnspeed, Space.World);
    }
}

