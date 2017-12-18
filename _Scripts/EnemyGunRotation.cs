using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunRotation : MonoBehaviour {

	private float x; 
	private Vector3 ls;
	private GameObject toShootAt;

	// Use this for initialization
	void Start()
	{
		x = transform.localScale.x;
		ls = transform.localScale;

		toShootAt = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		Vector3 dir = toShootAt.transform.position - transform.position;

		float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


		transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

		ls.x = x;
		transform.localScale = ls;

	}
}

