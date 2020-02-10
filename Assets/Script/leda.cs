using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leda : MonoBehaviour {
    public GameObject tank;
	// Use this for initialization
	void Start () {
		
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        Vector3 pos = tank.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y + 50, pos.z);
    }
}
