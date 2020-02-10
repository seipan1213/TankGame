using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    Rigidbody rid;
	// Use this for initialization
	void Start () {
        rid = this.GetComponent<Rigidbody>();
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "masi")
        {
            rid.AddForce(other.transform.forward * 40);
        }
    }
}
