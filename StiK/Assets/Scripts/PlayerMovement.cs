using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator playerAnimator;
    public Animator jetPackAnimator;
    public GameObject fire;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    private bool jetpackOn = false;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(Input.GetButtonDown("Jump"))
        {
            playerAnimator.SetBool("Jump", true);
            jump = true;
        }

        if (GetComponent<playerInventory>().items[GetComponent<playerInventory>().getActiveSlot()] != null)
        {
            if (GetComponent<playerInventory>().items[GetComponent<playerInventory>().getActiveSlot()].tag == "jetpack")
            {
                if (Input.GetButton("Jump"))
                {
                    jetpackOn = true;
                    fire.SetActive(true);
                    jetPackAnimator.SetBool("JetOn", true);
                }
                else
                {
                    jetpackOn = false;
                    fire.SetActive(false);
                    jetPackAnimator.SetBool("JetOn", false);
                }
            }

        }

    }

    public void onLanding()
    {
        playerAnimator.SetBool("Jump", false);
    }

    private void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump,jetpackOn);
        jump = false;
    }


}
