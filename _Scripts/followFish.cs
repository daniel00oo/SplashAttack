using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followFish : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
	public float smoothness = 5;


	int zoom = 3;
	int normal = 5;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	private bool far = false;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

		Vector3 pos = transform.position;
		pos.x = player.transform.position.x + offset.x;
		transform.position = pos;
		

		if (!far) {
			//Debug.Log ("I am not far lol");


			GetComponent<Camera> ().orthographicSize = Mathf.Lerp (GetComponent<Camera> ().orthographicSize, zoom, Time.deltaTime * smoothness);
		} else {
			//Debug.Log ("I am far lol");


			GetComponent<Camera> ().orthographicSize = Mathf.Lerp (GetComponent<Camera> ().orthographicSize, normal, Time.deltaTime * smoothness);
		}

    }

	public void zoomout() {
		far = true;
	}

	public void zoomin() {
		far = false;
	}

}
