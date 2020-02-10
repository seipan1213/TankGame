using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {


	// Use this for initialization
	void Start () {
        int c = Random.Range(1, 4);
        switch (c)
        {
            case 1:
                this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 2:
                this.gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;

        }
    }
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
		
	}
}
