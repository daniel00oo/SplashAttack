using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnEnter : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<followFish> ().zoomout ();
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<followFish> ().zoomin ();
		}
	}
}
