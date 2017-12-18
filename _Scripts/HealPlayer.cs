using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().playerHealed ();

			Destroy (gameObject);
		}
	}
}
