using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Transform player1;
    private Vector3 tempos;
    private Vector3 tempos1;
    public GameObject player11;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        player1 = GameObject.FindWithTag("car").transform;
    }

    // Update is called once per frame
    void Update()
    {
        tempos = transform.position;
        //if (player.position.x >= 0.13 && player.position.x <= 137f)
            tempos.x = player.position.x;
      //  if (player.position.y >= 1.05)
            tempos.y = player.position.y;

        transform.position = tempos;

        if (player11.active == false)
        {
            tempos1 = transform.position;
            //if (player.position.x >= 0.13 && player.position.x <= 137f)
            tempos.x = player1.position.x;
            //  if (player.position.y >= 1.05)
            tempos.y = player1.position.y;

            transform.position = tempos;
        }
        if(player11.active  == true)
        {
            tempos = transform.position;
            //if (player.position.x >= 0.13 && player.position.x <= 137f)
            tempos.x = player.position.x;
            //  if (player.position.y >= 1.05)
            tempos.y = player.position.y;
        }
    }
    

    // Update is called once per frame
   

}

