using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;
	
	public Transform BulletTrailPrefab;
	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;


    //private GameObject[] enemies;
    float timeToFire = 0;
	Transform firePoint;

	// Use this for initialization
	void Awake () {

		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");
		}
	}

    // Update is called once per frame
    void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot();
			}
		}
		else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}

    }
	
	void Shoot () {
		
		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
		}
		//Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.black);
	}
   
	void Effect () {
		Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
	}
}
