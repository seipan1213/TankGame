using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Siro : MonoBehaviour
{
    public Slider slider;
    public float HP = 5000;
    public GameObject respn;
    public GameObject respon;
    public GameObject enemy;
    public GameObject friend;
    public GameObject[] enemys;
    public GameObject[] friends;
    public GameObject text;
    private float zikan;
    // Use this for initialization
    void Start()
    {
        slider.maxValue = HP;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        zikan += Time.deltaTime;
        if (zikan >= 10 && text.activeSelf == false)
        {
            if (this.gameObject.name == "FriendSIRO")
            {
                friends = GameObject.FindGameObjectsWithTag("mikata");
                if (friends.Length <= 22)
                {
                    Instantiate(friend, respon.transform.position, respon.transform.rotation);
                }
            }
            else
            {
                enemys = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemys.Length <= 22)
                {
                    Instantiate(enemy, respn.transform.position, respn.transform.rotation);
                }
            }
            zikan = 0;
        }
        slider.value = HP;
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
