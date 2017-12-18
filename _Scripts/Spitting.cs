using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitting : MonoBehaviour {

   
    public GameObject splash;
    public float fireRate;
    private float timeToFire = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // daca e timpul sa traga si playerul trage =>cooldown  

            if (Input.GetButton("Fire1")&&Time.time>timeToFire)
            {
				
				
                Instantiate(splash, transform.position, transform.rotation);
                timeToFire = fireRate+Time.time;
            }

        }
	}