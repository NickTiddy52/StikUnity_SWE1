using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * -1;
    }
    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
    
    //Function is called when bullet is no longer visible, i.e. when it leaves the screen
    private void OnBecameInvisible()
    {
		//Destroys object once it is no longer visible
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
