﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    public CharacterController2D controller;
    public GameObject player2;
    public CharacterController2D controller2;
    float verticalMove = 0f;
    float verticalMove2 = 0f;

    public float ladderMoveSpeed = 20f;
    public bool canClimb = false;
    public bool canClimb2 = false;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxisRaw("Vertical1") * ladderMoveSpeed;
        verticalMove2 = Input.GetAxisRaw("Vertical2") * ladderMoveSpeed;

        if (canClimb)
        {
            controller.Climb(verticalMove * Time.fixedDeltaTime, false,false);

        }
        if (canClimb2)
        {
            controller2.Climb(verticalMove2 * Time.fixedDeltaTime, false, false);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            canClimb = true;

        }
        if (collision.gameObject.name.Equals("Player2"))
        {
            canClimb2 = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            canClimb = false;
        }
        if (collision.gameObject.name.Equals("Player2"))
        {
            canClimb2 = false;
        }
    }
}
