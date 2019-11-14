using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject tst;
    public GameObject placePoint;

    public GameObject parent;
    public bool pickUpValid;
    float gunRotation = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            parent.GetComponent<playerInventroy>().DropItem(this.gameObject);

        if (parent.GetComponent<playerInventroy>().items[parent.GetComponent<playerInventroy>().getActiveSlot()] == this.gameObject)
        {
            this.gameObject.transform.position = placePoint.transform.position;
            if (Input.GetAxis("Horizontal") <= -.1)
                gunRotation = 0;
            else if (Input.GetAxis("Horizontal") >= .1)
                gunRotation = 180;
            this.gameObject.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, gunRotation, this.transform.localEulerAngles.z);
            Collider2D collide = this.GetComponent<Collider2D>();
            collide.enabled = false;
            Rigidbody2D body = this.GetComponent<Rigidbody2D>();
            body.isKinematic = false;
            body.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (pickUpValid && Input.GetKeyDown(KeyCode.F))
            parent.GetComponent<playerInventroy>().AddItem(this.gameObject);
            //AddItem();

      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.name.Equals("Player"))
        {
            tst.SetActive(true);
            pickUpValid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            tst.SetActive(false);
            pickUpValid = false;
        }
    }
}
