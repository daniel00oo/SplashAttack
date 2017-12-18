using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepTimeToLoadScene : MonoBehaviour {

    private float timer;
    public float toAdd;

	// Use this for initialization
	void Start () {
        timer = toAdd + Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timer)
            SceneManager.LoadScene("mainMenu");
	}
}
