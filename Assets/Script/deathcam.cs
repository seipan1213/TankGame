using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathcam : MonoBehaviour {
    private GameObject tank;
	// Use this for initialization
	void Start () {
        tank = GameObject.Find("Tank");
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
    {
        if (tank != null)
        {
            this.transform.position = Camera.main.transform.position;
            this.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
