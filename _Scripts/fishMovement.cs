using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    public float speed;
    public string obstacle = "Rock";

    private Rigidbody2D fishrb2d;

    SpriteRenderer spr;
    public Animator myAnim;

    private bool IdleToWalk;
    private bool WalkToIdle;

    private bool IdleToSpit;
    private bool SpitToIdle;

    private bool SwimToSpit;
    private bool SpitToSwim;

    void Start()
    {
        fishrb2d = GetComponent<Rigidbody2D>();

        spr = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        fishrb2d.AddForce(movement * speed);

        fishrb2d.AddRelativeForce(speed * movement - fishrb2d.velocity);

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            WalkToIdle = false;
            IdleToWalk = true;
            myAnim.SetBool("WalkToIdle", WalkToIdle);
            myAnim.SetBool("IdleToWalk", IdleToWalk);

            if (Input.GetButton("Fire1"))

            {
                SwimToSpit = true; SpitToSwim = false;
                myAnim.SetBool("SwimToSpit", SwimToSpit);
                myAnim.SetBool("SpitToSwim", SpitToSwim);
            }
            else if (Input.GetButton("Fire1") == false) {
                SpitToSwim = true; SwimToSpit = false;
                myAnim.SetBool("SwimToSpit", SwimToSpit);
                myAnim.SetBool("SpitToSwim", SpitToSwim);
            }

        }
        else 
        {
            WalkToIdle = true;
            IdleToWalk = false;
            myAnim.SetBool("WalkToIdle", WalkToIdle);
            myAnim.SetBool("IdleToWalk", IdleToWalk);

        }


          





            if (moveHorizontal >= 0)
            {
                spr.flipX = false;
            }
            else
            {
                spr.flipX = true;
            }
            // fishYmovement();


        }
    }


