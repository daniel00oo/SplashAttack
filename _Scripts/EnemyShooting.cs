using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
	
	public GameObject projectile;	// with what to shoot
	public float fireCD;	// cooldown for enemy firing
	public float range;		// range for enemy firing
	public float projectileForce;

	private float keepTime;	
	private Vector3 force;
	private GameObject toShootAt;	// what to shoot at

	// Use this for initialization
	void Start () {
		keepTime = Time.time + fireCD;

		toShootAt = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// if the target is in range
		if (Mathf.Abs ((transform.position.y - toShootAt.transform.position.y)) + Mathf.Abs ((transform.position.x - toShootAt.transform.position.x)) < range) {
			// if it can fire, will do
			if (Time.time > keepTime) {
				shoot ();

				keepTime = Time.time + fireCD;	// putting a cooldown on firing
			}
		}
	}

	void shoot() {
		GameObject p = Instantiate (projectile, transform.position, transform.rotation);

		force = new Vector3 (projectileForce, 0, 0);
		p.GetComponent<Rigidbody2D> ().velocity = p.transform.TransformDirection(force);
	}
}
