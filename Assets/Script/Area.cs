using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour {

    public GameObject canvas;
    public Slider slider;
    private float AreaGage = 100;
    private GameObject tank;
    TankCon sensya;
    private float hpspeed;
    public GameObject friend;
    public int senkyo = 0;
    public GameObject enemy;
    public GameObject[] enemys;
    public GameObject[] friends;
    public GameObject text;

    private float resp;

    // Use this for initialization
    void Start () {
        tank = GameObject.Find("Tank");
        slider.maxValue = AreaGage;
        AreaGage /= 2;
        sensya = tank.GetComponent<TankCon>();

    }

    // FixedUpdate is called once per frame
    void FixedUpdate ()
    {
        if (tank != null && text.activeSelf == false)
        {
            canvas.transform.LookAt(Camera.main.transform);

            resp += Time.deltaTime;
            if (resp >= 20)
            {
                friends = GameObject.FindGameObjectsWithTag("mikata");
                if (friends.Length <= 32 && senkyo == 1)
                {
                    Instantiate(friend, this.transform.position, this.transform.rotation);
                    resp = 0;
                }
                enemys = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemys.Length <= 32 && senkyo == 2)
                {
                    Instantiate(enemy, this.transform.position, this.transform.rotation);
                    resp = 0;
                }
            }
            if (slider.value != slider.maxValue && slider.value != slider.minValue)
            {
                senkyo = 0;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mikata" || other.gameObject.tag == "Tank")
        {
            AreaGage += 0.1f;
            slider.value = AreaGage;
            if (slider.value == slider.maxValue)
            {
                hpspeed += Time.deltaTime;
                senkyo = 1;
                AreaGage = slider.maxValue;

                if (other.gameObject.name == "Tank" && sensya.tankHP <= 300 && hpspeed >= 0.25)
                {
                    sensya.slider.value = sensya.tankHP;
                    sensya.moji.text = sensya.tankHP.ToString();
                    sensya.tankHP += 1;
                    hpspeed = 0;
                }
            }
        }
        if (other.gameObject.tag == "Enemy")
        {
            AreaGage -= 0.1f;
            slider.value = AreaGage;
            if (slider.value == slider.minValue)
            {
                senkyo = 2;
                AreaGage = slider.minValue;
            }
        }
    }
}
