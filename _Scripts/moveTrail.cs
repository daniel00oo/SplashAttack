using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour {
    
    public int moveSpeed=20;

    // Use this for initialization
    void Start() {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.right*Time.deltaTime*moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Boss")) {

			if (col.gameObject.GetComponent<Health> ()) {
				col.gameObject.GetComponent<Health> ().takeDamage ();
			} else {
				Destroy (col.gameObject);
			}

			Destroy (gameObject);

        }
        //Debug.Log("Se collide cu col.gameobj" + col.gameObject);
    }

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
