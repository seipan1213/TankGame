using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repair : MonoBehaviour {

    TankCon hp;
    private GameObject tank;
    private AudioClip oto;
    Renderer rend;
    // Use this for initialization
    void Start () {
        tank = GameObject.Find("Tank");
        hp = tank.GetComponent<TankCon>();
        this.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        oto = gameObject.GetComponent<AudioSource>().clip;
        rend = GetComponent<Renderer>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate () {
        this.transform.Rotate(0, 1, 0);
        this.transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 3) * 0.5f + 1, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tank")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(oto);
            hp.tankHP += 100;
            if (hp.tankHP > 500) {
                hp.tankHP = 500;
            }
            hp.slider.value = hp.tankHP;
            hp.moji.text = hp.tankHP.ToString();
            Destroy(this.gameObject, 0.5f);
            rend.enabled = false;
        }
    }
}
