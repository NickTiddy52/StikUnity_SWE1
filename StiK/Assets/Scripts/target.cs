using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 50f;
    public GameObject tst;
    public GameObject button;
    public void takeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameObject.name == "Player")
        {
            tst.SetActive(true);
            button.SetActive(true);
        }
        if (gameObject.name == "Player2")
        {
            tst.SetActive(true);
            button.SetActive(true);
        }
        Destroy(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
