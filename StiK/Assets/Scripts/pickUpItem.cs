using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject tst;
    public GameObject placePoint1;
    public GameObject placePoint2;

    int playerNumber;
    public GameObject parent1;
    public GameObject parent2;

    public bool pickUpValid1;
    public bool pickUpValid2;

    float gunRotation = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            parent1.GetComponent<playerInventory>().DropItem(this.gameObject);

        if (Input.GetKeyDown(KeyCode.E))
            parent2.GetComponent<playerInventory>().DropItem(this.gameObject);

        if (parent1.GetComponent<playerInventory>().items[parent1.GetComponent<playerInventory>().getActiveSlot()] == this.gameObject)
        {
            this.gameObject.transform.position = placePoint1.transform.position;
            if (Input.GetAxis("Horizontal1") <= -.1)
                gunRotation = 0;
            else if (Input.GetAxis("Horizontal1") >= .1)
                gunRotation = 180;
            this.gameObject.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, gunRotation, this.transform.localEulerAngles.z);
            Collider2D collide = this.GetComponent<Collider2D>();
            collide.enabled = false;
            Rigidbody2D body = this.GetComponent<Rigidbody2D>();
            body.isKinematic = false;
            body.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (parent2.GetComponent<playerInventory>().items[parent2.GetComponent<playerInventory>().getActiveSlot()] == this.gameObject)
        {
            this.gameObject.transform.position = placePoint2.transform.position;
            if (Input.GetAxis("Horizontal2") <= -.1)
                gunRotation = 0;
            else if (Input.GetAxis("Horizontal2") >= .1)
                gunRotation = 180;
            this.gameObject.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, gunRotation, this.transform.localEulerAngles.z);
            Collider2D collide = this.GetComponent<Collider2D>();
            collide.enabled = false;
            Rigidbody2D body = this.GetComponent<Rigidbody2D>();
            body.isKinematic = false;
            body.constraints = RigidbodyConstraints2D.FreezePositionY;
        }


        if (pickUpValid1 && Input.GetKeyDown(KeyCode.J))
            parent1.GetComponent<playerInventory>().AddItem(this.gameObject);

        if (pickUpValid2 && Input.GetKeyDown(KeyCode.F))
            parent2.GetComponent<playerInventory>().AddItem(this.gameObject);
        //AddItem();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.name.Equals("Player"))
        {
            tst.SetActive(true);
            pickUpValid1 = true;
            parent1 = collision.gameObject;
        }

        if (collision.gameObject.name.Equals("Player2"))
        {
            tst.SetActive(true);
            pickUpValid2 = true;
            parent2 = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            tst.SetActive(false);
            pickUpValid1 = false;
        }

        if(collision.gameObject.name.Equals("Player2"))
        {
            tst.SetActive(false);
            pickUpValid2 = false;
        }

    }
}
