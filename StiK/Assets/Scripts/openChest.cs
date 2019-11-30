using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{
    public GameObject tst;
    public GameObject parent;
    public Animator chestAnimator;
    public GameObject chestItem;
    private bool pickUpValid1;
    private bool pickUpValid2;

    private bool opened =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!opened && (pickUpValid1 && Input.GetKeyDown(KeyCode.J) || pickUpValid2 && Input.GetKeyDown(KeyCode.F)))
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
            pickUpValid1 = true;
        }

        if (!opened && collision.gameObject.name.Equals("Player2"))
        {
            tst.SetActive(true);
            pickUpValid2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!opened && collision.gameObject.name.Equals("Player"))
        {
            tst.SetActive(false);
            pickUpValid1 = false;
        }
        if (!opened && collision.gameObject.name.Equals("Player2"))
        {
            tst.SetActive(false);
            pickUpValid2 = false;
        }

    }
}
