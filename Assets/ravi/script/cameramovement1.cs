using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player1;
    //private Transform player11;
    private Vector3 tempos1;
    private Vector3 tempos11;
    //public GameObject player111;
    void Start()
    {
        player1 = GameObject.FindWithTag("Player").transform;
        //player11 = GameObject.FindWithTag("car").transform;
    }

    // Update is called once per frame
    void Update()
    {
        tempos1 = transform.position;
        //if (player.position.x >= 0.13 && player.position.x <= 137f)
            tempos1.x = player1.position.x;
      //  if (player.position.y >= 1.05)
            tempos1.y = player1.position.y;

        transform.position = tempos1;

        
    }
    

    // Update is called once per frame
   

}

