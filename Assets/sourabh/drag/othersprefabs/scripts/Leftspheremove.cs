using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leftspheremove : MonoBehaviour
{
    Rigidbody rb;
    public AudioSource audio;
    public Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "gd")
        {
            rb.AddForce(Vector3.up * 15f, ForceMode.Impulse);
            float x = player.position.x - transform.position.x;
            if (Mathf.Abs(x) <= 2)
            {
                audio.Play();
            }

        }
    }
}
    

