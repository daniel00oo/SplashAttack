using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyAI : MonoBehaviour {

	public float acceleration;
	public float maxSpeed;
	public float hiperactiveness;
	public float movementBoundary;	// how far left and right it will go

	private Vector3 pos; // will be used for rat shivering
	private int leftOrRight = 1;	// a variable used in shivering
	private bool goingRight = false;	// true if it's going right or false otherwise
	private float shiverTimer;		// a timer user in the shivering of the boss
	private float shiverConstTimer = 0.05f;
	private Vector3 startpos;	// starting position
	private Vector3 forceToAdd;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		shiverTimer = Time.time;

		rb = gameObject.GetComponent<Rigidbody2D> ();
		startpos = transform.position;	// saving the starting position
		forceToAdd = new Vector3(acceleration, 0, 0);	// force that will behave like acceleration on the X axis
	}
	
	// Update is called once per frame
	void Update () {
		shiver ();		// comment this if you want no shiver


		movement ();	// movement left and right is here, comment this if you don't want movement

		flipOnSpeed ();	// flipping the object according to the speed, comment this if you don't want flipping
	}

	void shiver() {
		if (Time.time > shiverTimer) {
			pos = transform.position;
			pos += (Vector3.right + Vector3.up) * leftOrRight * hiperactiveness;

			transform.position = pos;

			leftOrRight *= -1;

			shiverTimer = Time.time + shiverConstTimer;
		}
	}

	void movement() {
		if (goingRight) {	// if the Boss is supposed to go right
			if (transform.position.x < startpos.x + movementBoundary) {	// if has not touched the right boundary
				if (rb.velocity.magnitude > maxSpeed) {	// if has reached the MAXIMUM OVERBORK--I mean maximum speed, will not accelerate further
					rb.velocity = rb.velocity.normalized * maxSpeed;
				} else {
					rb.AddForce (forceToAdd);	// add force to the right
				}
			} else {
				goingRight = !goingRight;
			}
		} else {	// is supposed to go left
			if (transform.position.x > startpos.x - movementBoundary) {	// if has not touched the left boundary
				if (rb.velocity.magnitude > maxSpeed) {	// if has reached the MAXIMUM OVERBORK--I mean maximum speed, will not accelerate further
					rb.velocity = rb.velocity.normalized * maxSpeed;
				} else {
					rb.AddForce (forceToAdd * -1);	// add force to the left
				}
			} else { 
				goingRight = !goingRight;
			}
		}
	}

	void flipOnSpeed() {
		if (rb.velocity.x < 0) {	// if it's going left
			if (transform.localScale.x < 0) {	// if we haven't flipped it, we flip it
				Vector3 newScale = transform.localScale;
				newScale.x *= -1;
				transform.localScale = newScale;
			}
		} else {	// else is going right
			if (transform.localScale.x > 0) {
				Vector3 newScale = transform.localScale;
				newScale.x *= -1;
				transform.localScale = newScale;
			}
		}
	}
}
