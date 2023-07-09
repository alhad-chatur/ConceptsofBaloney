using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sec_light : MonoBehaviour
{

    LineRenderer lr;
    RaycastHit2D rh;
    public GameObject l2;
    bool rerf = false;
    GameObject newl;
    public Vector3 direction = Vector3.zero;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        rh = Physics2D.Raycast(transform.position,direction);
        lr.SetPosition(1, rh.point);
        Debug.Log(rh.collider.name);
    }
}
