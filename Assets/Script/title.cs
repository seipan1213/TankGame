using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {
    public GameObject FRsiro;
    public GameObject ENsiro;
    public GameObject tank;
    public Button button;


    // Use this for initialization
    void Start () {
        button.gameObject.SetActive(false);
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        if (FRsiro == null || ENsiro == null || tank == null)
        {
            button.gameObject.SetActive(true);
        }
    }
        public void Button()
    {
        SceneManager.LoadScene("title");
    }

}
