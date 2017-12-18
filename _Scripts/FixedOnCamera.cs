using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedOnCamera : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;

		pos.z = 100;
		transform.position = pos;
	}
}
