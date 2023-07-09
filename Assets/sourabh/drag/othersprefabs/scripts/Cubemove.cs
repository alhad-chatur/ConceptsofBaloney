using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubemove : MonoBehaviour
{
    
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("anti"))
        {
            rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
            
        }
        else
        {
            
        }
    }


}
