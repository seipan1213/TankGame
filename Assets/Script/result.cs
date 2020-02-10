using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class result : MonoBehaviour {

    public GameObject FRsiro;
    public GameObject ENsiro;
    public GameObject tank;
    private float zikan;
    public Text text;

	// Use this for initialization
	void Start () {
        text.gameObject.SetActive(false);
    }

    // FixedUpdate is called once per frame
    void FixedUpdate () {
        if (FRsiro == null || tank == null)
        {
            zikan = +Time.deltaTime;
            if (zikan > 0.5f)
            {
                Time.timeScale = 0;
            }
            Cursor.visible = true;
            text.text = "LOSE";
            text.gameObject.SetActive(true);
        }
        else if(ENsiro == null)
        {
            zikan = +Time.deltaTime;
            if (zikan > 0.5f)
            {
                Time.timeScale = 0;
            }
            Time.timeScale = 0;
            Cursor.visible = true;
            text.text = "WIN";
            text.gameObject.SetActive(true);
        }

    }
}
