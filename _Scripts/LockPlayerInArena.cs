using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerInArena : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			transform.GetChild (0).gameObject.SetActive (true);

			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<followFish> ().player = gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.isActiveAndEnabled && col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<followFish> ().player = GameObject.FindGameObjectWithTag ("Player");
		}
	}

	public void unlockPlayer() {
		transform.GetChild (0).gameObject.SetActive (false);
	}
}
