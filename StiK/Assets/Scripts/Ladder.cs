using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    public CharacterController2D controller;
    float verticalMove = 0f;
    float ladderMoveSpeed = 20f;
    public bool canClimb = false;

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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            canClimb = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            canClimb = false;
        }
    }
}
