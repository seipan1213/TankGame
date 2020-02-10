using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
		
	}
    public void Button()
    {
        SceneManager.LoadScene("GameScene");
    }
}
