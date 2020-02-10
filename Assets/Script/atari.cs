using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atari : MonoBehaviour {

    Siro siro;
    public GameObject kyoten;
	// Use this for initialization
	void Start () {
      siro = kyoten.GetComponent<Siro>();
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tama")
        {
            siro.HP -= 50;
        }
        if (other.gameObject.tag == "masi")
        {
            siro.HP -= 2;
        }
        if (other.gameObject.tag == "Fire")
        {
            siro.HP -= 2f;
        }
    }

}
