using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerInventory : MonoBehaviour
{
    public GameObject[] items = new GameObject[4];
    public int activeSlot = 0;
    public int maxInventory = 4;
    public int playerNumber;
    public void AddItem(GameObject itemToAdd)
    {
        Debug.Log("ItemPickedUp" + items[0]);
        int addSlot = nextOpenSlot();
        if(addSlot != maxInventory + 1)
        {
            items[addSlot] = itemToAdd;
            if(activeSlot != addSlot)
                itemToAdd.SetActive(false);

        }
        else{
            DropItem(items[activeSlot]);
            items[activeSlot] = itemToAdd;
        }
    }

    public void DropItem(GameObject itemToDrop)
    {
        if (itemToDrop == null)
            return;
        for(int i = 0; i < maxInventory; i++)
        {
            if(itemToDrop.name == items[i].name)
            {
                items[i] = null;
                break;
            }
        }
        Collider2D collide = itemToDrop.GetComponent<Collider2D>();
        collide.enabled = true;
        Rigidbody2D body = itemToDrop.GetComponent<Rigidbody2D>();
        //body.isKinematic = true;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public bool inventoryEmpty()
    {
        if (items[activeSlot] == null) return true;
        else return false;
    }

    private int nextOpenSlot()
    {
        for(int i = 0; i < maxInventory; i++)
        {
            if (items[i] == null)
            {
                Debug.Log(i);
                return i;
            }
        }
        return maxInventory + 1;
    }

    private void weaponSwap(int swapId)
    {
        if(items[activeSlot] != null)
            items[activeSlot].SetActive(false);

        activeSlot = swapId;
        if (items[activeSlot] != null)
            items[activeSlot].SetActive(true);
    }

    public int getActiveSlot()
    {
        return activeSlot;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                weaponSwap(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                weaponSwap(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                weaponSwap(2);
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                weaponSwap(3);
        }
        else if (playerNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha7))
                weaponSwap(0);
            else if (Input.GetKeyDown(KeyCode.Alpha8))
                weaponSwap(1);
            else if (Input.GetKeyDown(KeyCode.Alpha9))
                weaponSwap(2);
            else if (Input.GetKeyDown(KeyCode.Alpha0))
                weaponSwap(3);
        }
    }
}
