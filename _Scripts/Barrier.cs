using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

	private GameObject player;
	private Vector3 aux;

	// Use this for initialization
	void Start () {
		aux = transform.position;

		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		aux.x = player.transform.position.x;

		transform.position = aux;
	}
}
