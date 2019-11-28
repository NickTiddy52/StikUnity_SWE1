using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    public CharacterController2D controller;
    public CharacterController2DPlayer2 controllerPlayer2;
    float verticalMove = 0f;
    public float ladderMoveSpeed = 20f;
    public bool canClimb = false;
    public bool canClimbPlayer2 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxisRaw("Vertical") * ladderMoveSpeed;

        if (canClimb)
        {
            controller.Climb(verticalMove * Time.fixedDeltaTime, false,false);

        }
		
		if (canClimbPlayer2)
        {
            controllerPlayer2.Climb(verticalMove * Time.fixedDeltaTime, false,false);

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
            canClimbPlayer2 = true;
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
            canClimbPlayer2 = false;
        }
    }
}
