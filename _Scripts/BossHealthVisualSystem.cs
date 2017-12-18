using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthVisualSystem : MonoBehaviour {

	public GameObject[] hearts;

	private int lifesRemaining;

	void Start() {
		lifesRemaining = hearts.Length - 1;
	}
	
	public void bossTookDamage() {
		if (lifesRemaining >= 0) {
			hearts [lifesRemaining].SetActive (false);
			lifesRemaining--;
		}
	}
}
