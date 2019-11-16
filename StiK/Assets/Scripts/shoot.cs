using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject player;
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public LineRenderer lineRenderer;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()] != null){
                if (player.GetComponent<playerInventory>().items[player.GetComponent<playerInventory>().getActiveSlot()].tag == "shoot")
                    Shoot();
            }
        }
        
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(shootPoint.position, shootPoint.right * -1,1000,layerMask: 9);
        Debug.DrawRay(shootPoint.position, shootPoint.right,Color.green);
        if(hitInfo)
        {
            target target = hitInfo.transform.GetComponent<target>();
            if(target != null)
            {
                target.takeDamage(damage);
            }
            Debug.Log("Hit: " + hitInfo.transform.name);
            lineRenderer.SetPosition(0, shootPoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, shootPoint.position);
            lineRenderer.SetPosition(1, shootPoint.position + shootPoint.right * 100);
        }
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);


    }
}
