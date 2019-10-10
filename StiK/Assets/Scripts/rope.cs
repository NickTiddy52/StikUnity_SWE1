using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    private bool connectToRopeValid = false;
    private bool isOnRope = false;
    public DistanceJoint2D playerJoint;
    public Rigidbody2D ropeConnectPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (connectToRopeValid && Input.GetKeyDown(KeyCode.F))
        {
            playerJoint.connectedBody = ropeConnectPoint;
            isOnRope = true;
        }

        if(isOnRope == true && Input.GetKeyDown(KeyCode.E))
        {
            playerJoint.connectedBody = playerJoint.GetComponentInParent<Rigidbody2D>();
            isOnRope = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            connectToRopeValid = true;
            ropeConnectPoint = GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            connectToRopeValid = false;
        }
    }
}
