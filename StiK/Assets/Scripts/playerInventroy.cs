using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerInventroy : MonoBehaviour
{
    public GameObject[] items = new GameObject[4];
    
    public void AddItem(GameObject itemToAdd)
    {
        items[0] = this.gameObject;
        Debug.Log("ItemPickedUp");
    }

    public bool inventoryEmpty()
    {
        if (items[0] == null) return true;
        else return false;
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
