﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    private float Range;
    public float Speed;


    // Use this for initialization
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Rock");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        if (Range <= 5f)
        {
            transform.Translate(Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, Range) * Speed * Time.deltaTime);
        }

    }
}

