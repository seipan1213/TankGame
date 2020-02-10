using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class sokudoEnemy : MonoBehaviour
{
    public GameObject enemy;
    teki tk;
    Animator anime;
    private float toki;
    private bool old = true;
    // Use this for initialization
    void Start()
    {
        //enemy = GameObject.Find("Enemy");
        tk = enemy.GetComponent<teki>();
        anime = GetComponent<Animator>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        while (old) 
        {
            toki = tk.enemyHP;
            old = false;
        }

        this.anime.SetFloat("Speed", tk.enemyHP / toki);
    }
}
