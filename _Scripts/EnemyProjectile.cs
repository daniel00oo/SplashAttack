using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Health> ().takeDamage ();


			Destroy (gameObject);
		}
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
