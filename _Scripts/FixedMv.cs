using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMv : MonoBehaviour {
	Vector3 v;
	private float y;

	// Use this for initialization
	void Start () {
		y = transform.position.y;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		v = transform.position;
		v.y = y;

		transform.position = v;
	}
}
