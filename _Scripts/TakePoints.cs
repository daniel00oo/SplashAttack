using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePoints : MonoBehaviour {

	private GameObject gm;
	private Text ui;
	private int points;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.GetComponent<GivesPoints> ()) {
			points = col.gameObject.GetComponent<GivesPoints> ().points;

			gm.GetComponent<GameController>().addToScore (points);
			gm.GetComponent<GameController>().updateScore ();
		}
	}

}
