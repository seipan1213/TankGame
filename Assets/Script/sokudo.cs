using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class sokudo : MonoBehaviour {
    public GameObject tank;
    TankCon tk;
    Animator anime;
    private float toki;
	// Use this for initialization
	void Start () {
        tk = tank.GetComponent<TankCon>();
        anime = GetComponent<Animator>();
        toki = tk.tankHP;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {

        this.anime.SetFloat("Speed", tk.tankHP / toki);
    }
}
