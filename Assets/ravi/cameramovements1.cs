using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovements1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Vector3 tempos;
    void Start()
    {
        player = GameObject.FindWithTag("car").transform;
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
    }

}

