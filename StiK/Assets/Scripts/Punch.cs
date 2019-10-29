using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public GameObject punchField;
    public target target;
    public float hitDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(target)
                PunchObj();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.transform.GetComponent<target>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(target != null)
        {
            if (target.transform.name == collision.name)
            {
                target = null;
            }
        }

    }
    void PunchObj()
    {
        target.takeDamage(hitDamage);
    }
}
