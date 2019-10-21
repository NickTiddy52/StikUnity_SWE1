using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float respawnDistance;
    public Vector2 respawnPoint;
    void FixedUpdate()
    {
        if (transform.position.y < respawnDistance)
            transform.position = respawnPoint;
    }
}
