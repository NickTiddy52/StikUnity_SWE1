using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 100f;
    public Rigidbody2D rb;
    private int maxDistance = 100;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * -1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        target target = collision.transform.GetComponent<target>();
        if(target)
        {
            target.takeDamage(damage);

        }
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (transform.position.x < -maxDistance || transform.position.x > maxDistance)
            Destroy(gameObject);
    }
}
