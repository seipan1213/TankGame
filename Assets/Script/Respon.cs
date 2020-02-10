using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respon : MonoBehaviour {

    public GameObject tank;
    public Vector3 posi;
    public Quaternion rota;



    // Use this for initialization
    void Start () {
        posi = tank.transform.position;
        rota = tank.transform.rotation;

    }
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        if (tank == null)
        {
            Instantiate(tank, posi, rota);
        }
	}
}
