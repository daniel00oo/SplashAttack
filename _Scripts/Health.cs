using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health = 3;
	public float invTime;

	private bool invincible;
	private float invtimer;
	private int maxHealth;

	private SpriteRenderer sp;

	// Use this for initialization
	void Start () {
		makeInvincible ();
		invtimer = Time.time + invTime;

		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		if (invincible && Time.time > invtimer) {
			makeVulnerable ();
		}

		if (health < 1)
			die ();

       

    }

	public void makeInvincible() {
		if (!invincible) {
			invincible = true;

			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.5f); 

			invtimer = Time.time + invTime;
		}
	}

	void makeVulnerable() {
		invincible = false;

		sp = gameObject.GetComponent<SpriteRenderer> ();

		sp.color = new Color (1f, 1f, 1f, 1f);
	}

	public void takeDamage() {
		if (!invincible) {
			health--;
			makeInvincible ();

			if (gameObject.tag == "Player")
				GameObject.Find ("GameController").GetComponent<GameController> ().playerTookDamage ();
			else if (gameObject.tag == "Boss") {
				transform.GetChild (1).GetComponent<BossHealthVisualSystem> ().bossTookDamage ();
			}
		}
	}

	void die() {
		if (gameObject.tag == "Player")
			playerDeath ();
		else if (gameObject.tag == "Enemy")
			Destroy (gameObject);
		else if (gameObject.tag == "Boss") {
			bossDeath ();
            Application.LoadLevel("final");
            //GameController.bossesDefeated++;
        }
	}

	void bossDeath() {


		// add here what you want to happen before the boss gameObject is destroyed


		if (GameObject.FindGameObjectWithTag ("BattleArena"))
			GameObject.FindGameObjectWithTag ("BattleArena").SetActive (false);
		Destroy (gameObject);	
	}

	public void playerDeath() {

		GameController.gameEnd = true;

		// put whatever you want before the player will disappear into the dark void

		gameObject.SetActive (false);

        Application.LoadLevel("RestartScene");
    }

	public void heal() {
		if (health < maxHealth)
			health++;	
	}


}
