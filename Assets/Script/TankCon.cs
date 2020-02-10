using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TankCon : MonoBehaviour {

    public Slider slider;
    public Text moji;
    private float speed = 3300;
    public float turnspeed = 0.02f;
    Rigidbody rid;
    public float tankHP=500;
    public GameObject houdai;
    private bool seti;
    public GameObject Explo;
    public Vector3 start;

    // Use this for initialization
    void Start () {
        rid = GetComponent<Rigidbody>();
        slider.maxValue = tankHP;
        slider.value = tankHP;
        moji.text = tankHP.ToString();
        start = this.gameObject.transform.position;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate () {
        float suihei= this.transform.rotation.y;
        if (seti)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rid.AddForce(transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rid.AddForce(transform.forward * -speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * turnspeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * turnspeed);
            }
            if (Input.GetKey(KeyCode.C))
            {
                transform.rotation = Quaternion.identity;
                houdai.transform.rotation = Quaternion.identity;

            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tama")
        {
            tankHP -= 50;
            slider.value = tankHP;
            moji.text = tankHP.ToString();
        }
        if (other.gameObject.tag == "masi")
        {
            tankHP -= 8;
            slider.value = tankHP;
            moji.text = tankHP.ToString();

        }
        if (other.gameObject.tag == "Fire")
        {
            tankHP -= 2f;
            slider.value = tankHP;
            moji.text = tankHP.ToString();

        }
        if (tankHP <= 0)
        {
            GameObject baku = Instantiate(Explo) as GameObject;
            baku.transform.position = this.transform.position;
            Destroy(baku.gameObject, 3.0f);
            this.gameObject.transform.position = start;
            tankHP = 500;
            slider.value = tankHP;
            moji.text = tankHP.ToString();

        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            seti = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            seti = false;
        }

    }
}
