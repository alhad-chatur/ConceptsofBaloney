using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingcubes : MonoBehaviour
{
    public Rigidbody player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);

            player.useGravity = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null) ;
            player.useGravity = true;
        }
    }
}
