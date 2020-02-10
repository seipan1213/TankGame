using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class sokudomikata : MonoBehaviour
{
    public GameObject mikata;
    mikata tk;
    Animator anime;
    private float toki;
    private bool old = true;
    // Use this for initialization
    void Start()
    {
        //mikata = GameObject.Find("mikata");
        tk = mikata.GetComponent<mikata>();
        anime = GetComponent<Animator>();

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        while (old)
        {
            toki = tk.mikataHP;
            old = false;
        }

        this.anime.SetFloat("Speed", tk.mikataHP / toki);
    }
}
