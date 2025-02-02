﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject player;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if(player.name == "Player")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Fire1");
                if (player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()] != null)
                {
                    if (player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()].tag == "shoot")
                        Shoot();
                }
            }
        }

        if (player.name == "Player2")
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()] != null)
                {
                    if (player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()].tag == "shoot")
                        Shoot2();
                }
            }
        }

    }
    void Shoot2()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(shootPoint2.position, shootPoint2.right * -1, 1000);
        //Debug.DrawRay(shootPoint2.position, shootPoint2.right, Color.green);
        //if (hitInfo)
        //{
        //    target target = hitInfo.transform.GetComponent<target>();
        //    if (target != null)
        //    {
        //        target.takeDamage(damage);
        //    }
        //    Debug.Log("Hit: " + hitInfo.transform.name);
        //    lineRenderer.SetPosition(0, shootPoint2.position);
        //    lineRenderer.SetPosition(1, hitInfo.point);
        //}
        //else
        //{
        //    lineRenderer.SetPosition(0, shootPoint2.position);
        //    lineRenderer.SetPosition(1, shootPoint2.position + shootPoint2.right * 100);
        //}

        Instantiate(bulletPrefab, player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()].transform.GetChild(0).position, player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()].transform.GetChild(0).rotation);


    }
    void Shoot()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(shootPoint.position, shootPoint.right * -1,1000);
        //Debug.DrawRay(shootPoint.position, shootPoint.right,Color.green);
        //if(hitInfo)
        //{
        //    target target = hitInfo.transform.GetComponent<target>();
        //    if(target != null)
        //    {
        //        target.takeDamage(damage);
        //    }
        //    Debug.Log("Hit: " + hitInfo.transform.name);
        //    lineRenderer.SetPosition(0, shootPoint.position);
        //    lineRenderer.SetPosition(1, hitInfo.point);
        //}
        //else
        //{
        //    lineRenderer.SetPosition(0, shootPoint.position);
        //    lineRenderer.SetPosition(1, shootPoint.position + shootPoint.right * 100);
        //}
        Instantiate(bulletPrefab, player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()].transform.GetChild(0).position, player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()].transform.GetChild(0).rotation);


    }
}
