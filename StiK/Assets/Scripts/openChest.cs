using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{
    public GameObject tst;
    public GameObject parent;
    public Animator chestAnimator;
    public GameObject chestItem;
    private bool pickUpValid;
    private bool pickUpValidPlayer2;
    private bool opened =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!opened && pickUpValid && Input.GetKeyDown(KeyCode.F))
        {
            chestAnimator.SetBool("isOpen", true);
            opened = true;
            tst.SetActive(false);
            Instantiate(chestItem, this.transform.position, chestItem.transform.rotation);

        }


		if (!opened && pickUpValidPlayer2 && Input.GetKeyDown(KeyCode.X))
        {
            chestAnimator.SetBool("isOpen", true);
            opened = true;
            tst.SetActive(false);
            Instantiate(chestItem, this.transform.position, chestItem.transform.rotation);

        }
    }
      
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!opened && collision.gameObject.name.Equals("Player"))
        {
            tst.SetActive(true);
            pickUpValid = true;
        }
		
		if (!opened && collision.gameObject.name.Equals("Player2"))
        {
            tst.SetActive(true);
            pickUpValidPlayer2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!opened && collision.gameObject.name.Equals("Player"))
        {
            tst.SetActive(false);
            pickUpValid = false;
        }
		
		if (!opened && collision.gameObject.name.Equals("Player2"))
        {
            tst.SetActive(false);
            pickUpValidPlayer2 = false;
        }
    }
}
