using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static bool gameEnd = false;
    public static int bossesDefeated = 0;
    public static int nrOfBosses;

	public Text ui;
	public GameObject battleArena;	// used for the prefab battle arena
	public int scoreToSpawnBoss;
	public GameObject[] boss;


	private GameObject player;

	private Image life1;
	private Image life2;
	private Image life3;

	private int currentBoss;
	private GameObject battlearena;	// used for the initialisation of a battle arena
	private int totalScore;
	private Vector3 pos;	
	private GameObject overscreen;
	private float elapsedTime;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		totalScore = 0;
		updateScore ();

		battlearena = Instantiate(battleArena);
		battlearena.SetActive (false);
		pos = battlearena.transform.position;

		currentBoss = 0;

		life1 = GameObject.Find ("Life1").GetComponent<Image>();
		life2 = GameObject.Find ("Life2").GetComponent<Image>();
		life3 = GameObject.Find ("Life3").GetComponent<Image>();

		overscreen = GameObject.Find ("GameOverScreen");
		overscreen.SetActive (false);

        nrOfBosses = boss.Length;
	}

	void Update() {
		if (totalScore >= scoreToSpawnBoss) {
			scoreToSpawnBoss = scoreToSpawnBoss * 2;	// we double the score we need to spawn the next boss;
			spawnBoss ();
			currentBoss++;


			// what will happen after the last boss was defeated

			if (bossesDefeated >= boss.Length)

                Application.LoadLevel("final");
        }
		if (gameEnd) {
			// killing all remaining enemies
			//killAllEnemies ();

			// setting it visible
			overscreen.SetActive(true);

			// getting the canvas
			Canvas can = GameObject.Find("Canvas").GetComponent<Canvas>();

			// slowly making the game over screen slide into view
			if (overscreen.transform.position.y > can.transform.position.y + 0.01)
				overscreen.transform.position = Vector3.Lerp (new Vector3(Screen.width/2, overscreen.transform.position.y, 0), new Vector3(Screen.width/2, can.transform.position.y, 0), 4 * Time.deltaTime);

		}
	}

	public void addToScore(int toAdd) {
		totalScore += toAdd;
	}

	public void updateScore() {
		ui.text = "Score: " + totalScore;
	}

	void spawnBoss() {
		pos.x = GameObject.FindGameObjectWithTag ("Player").transform.position.x;
		battlearena.transform.position = pos;
		battlearena.SetActive (true);

		Instantiate (boss[currentBoss], new Vector3 (battlearena.transform.position.x, boss[currentBoss].transform.position.y, boss[currentBoss].transform.position.z), Quaternion.identity);

	}

	public void playerTookDamage() {
		if (life3.IsActive ())
			life3.gameObject.SetActive (false);
		else if (life2.IsActive ())
			life2.gameObject.SetActive (false);
		else if (life1.IsActive())
			life1.gameObject.SetActive (false);
	}

	public void playerHealed() {
		player.GetComponent<Health> ().heal ();
		if (life2.IsActive () == false) {
			life2.gameObject.SetActive (true);
		} else if (life3.IsActive () == false) {
			life3.gameObject.SetActive (true);
		}
	}

	void killAllEnemies() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		foreach (GameObject enemy in enemies) {
			Destroy (enemy);
		}

		if (GameObject.FindGameObjectWithTag ("Boss"))
			Destroy (GameObject.FindGameObjectWithTag ("Boss"));
	}
}
