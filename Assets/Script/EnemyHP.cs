using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHP : MonoBehaviour {

    public Slider slider;
    private float enemyHP;
    public GameObject Canva;
    public GameObject Explo;

    // Use this for initialization
    void Start() {
        enemyHP = Random.Range(50, 200);
        slider.maxValue = enemyHP;
        slider.value = enemyHP;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate() {
        Canva.transform.LookAt(Camera.main.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tama")
        {
            enemyHP -= 70;
            slider.value = enemyHP;
        }
        if (other.gameObject.tag == "masi")
        {
            enemyHP -= 2;
            slider.value = enemyHP;

        }
        if (other.gameObject.tag == "Fire")
        {
            enemyHP -= 2f;
            slider.value = enemyHP;

        }
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
            GameObject baku = Instantiate(Explo) as GameObject;
            baku.transform.position = this.transform.position;
            Destroy(baku.gameObject, 3.0f);
        }
    }
}
