using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class hit : MonoBehaviour {

    public GameObject Explo;

    // Use this for initialization
    void Start () {
        if (this.gameObject.tag == "Fire")
        {
            Destroy(this.gameObject, 0.2f);
        }
        else
        {
            Destroy(this.gameObject, 7f);
        }
    }

    // FixedUpdate is called once per frame
    void FixedUpdate () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "tama" && other.gameObject.tag != "masi" && other.gameObject.tag != "Fire")
        {
            if (this.gameObject.tag == "tama")
            {
                GameObject baku = Instantiate(Explo) as GameObject;
                baku.transform.position = this.transform.position;
                Destroy(this.gameObject);
                Destroy(baku.gameObject, 3.0f);
            }
            if (this.gameObject.tag == "masi")
            {
                Destroy(this.gameObject);
            }
        }

    }
}
