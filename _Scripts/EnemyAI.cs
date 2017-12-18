using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public GameObject projectile;
    
	public float aiRange = 1;
    public float aiSpeed = 15;

    private Rigidbody2D AI;

    Vector2 aiTransform;
    Vector2 aiMovement = new Vector2(5f, 0f);

    public Animator antAnim;

    private bool IdleToRun;
    private bool RunToIdle;

    // Use this for initialization
    void Start () {
        
        AI = GetComponent<Rigidbody2D>();
        aiTransform = transform.position;
        antAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.x > aiTransform.x + aiRange) {
            aiMovement.Set(-5f, 0f);
			GetComponent<SpriteRenderer> ().flipX = true;
            IdleToRun = true;
            RunToIdle = false;
            antAnim.SetBool("IdleToRun", IdleToRun);
            antAnim.SetBool("RunToIdle", RunToIdle);
        }
       else if (gameObject.transform.position.x < aiTransform.x - aiRange) {
            aiMovement.Set(5f, 0f);
			GetComponent<SpriteRenderer> ().flipX = false;
           
        }


        AI.AddForce(aiMovement * aiSpeed * Time.deltaTime);

        AI.AddRelativeForce(aiMovement*aiSpeed*Time.deltaTime-AI.velocity);
	}
}
