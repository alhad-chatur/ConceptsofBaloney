using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    Rigidbody rb;
    public Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x= transform.position.x - target.position.x;
        float y = Random.Range(10, 20);
        if (x<2)
        {
            rb.useGravity = true;
            rb.velocity = new Vector3(0,-y, 0);
        }
    }
}
