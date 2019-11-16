using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 100f;
    public Rigidbody2D rb;
    private int maxDistance = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * -1;
    }
    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (transform.position.x < -maxDistance || transform.position.x > maxDistance)
            Destroy(gameObject);
    }
}
