using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 追加しましょう（ポイント）
using UnityEngine.UI;

public class Aim : MonoBehaviour
{

    public Image aimImage;
    public GameObject barrel;

     void Start()
    {
        Cursor.visible = false;
    }

    void FixedUpdate()
    {

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 200, Color.red, Time.deltaTime);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {

            string hitName = hit.transform.gameObject.tag;

            if (hitName == "Enemy")
            {

                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
            }
            else
            {

                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 0.4f);
            }
        }
        else
        {
            aimImage.color = new Color(0.0f, 1.0f, 1.0f,0.4f);
        }
    }
}