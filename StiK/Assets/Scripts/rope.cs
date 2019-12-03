using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    private bool connectToRopeValid = false;
    private bool isOnRope = false;
    public DistanceJoint2D playerJoint;
    public Rigidbody2D ropeConnectPoint;
    private bool connectToRopeValid2 = false;
    private bool isOnRope2 = false;
    public DistanceJoint2D playerJoint2;
    public Rigidbody2D ropeConnectPoint2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (connectToRopeValid && Input.GetKeyDown(KeyCode.J))
        {
            playerJoint.connectedBody = ropeConnectPoint;
            isOnRope = true;
        }

        if(isOnRope == true && Input.GetKeyDown(KeyCode.K))
        {
            playerJoint.connectedBody = playerJoint.GetComponentInParent<Rigidbody2D>();
            isOnRope = false;
        }

        if (connectToRopeValid2 && Input.GetKeyDown(KeyCode.F))
        {
            playerJoint2.connectedBody = ropeConnectPoint2;
            isOnRope2 = true;
        }

        if (isOnRope2 == true && Input.GetKeyDown(KeyCode.E))
        {
            playerJoint2.connectedBody = playerJoint2.GetComponentInParent<Rigidbody2D>();
            isOnRope2 = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            connectToRopeValid = true;
            ropeConnectPoint = GetComponent<Rigidbody2D>();
        }
        if (collision.gameObject.name.Equals("Player2"))
        {
            connectToRopeValid2 = true;
            ropeConnectPoint2 = GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            connectToRopeValid = false;
        }
        if (collision.gameObject.name.Equals("Player2"))
        {
            connectToRopeValid2 = false;
        }
    }
}
