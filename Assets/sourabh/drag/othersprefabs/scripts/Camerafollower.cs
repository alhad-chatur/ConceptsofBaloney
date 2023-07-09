using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollower : MonoBehaviour
{

    public Transform target;
    public GameObject player;
    public float smoothspeed = 0.125f;
    public Vector3 offset;
    public GameObject monkey;
    float x = 0;
    float y = 0;

    void Update()
    {

        Vector3 des_pos = target.position + offset;

        Vector3 smooth_pos = Vector3.Lerp(transform.position, des_pos, smoothspeed);
        transform.position = smooth_pos;


        if ((player.transform.position.x > -4.61f && player.transform.position.x < 49.33f) && player.transform.position.y < 6f)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if ((player.transform.position.x > 11f && player.transform.position.x < 40f) && player.transform.position.y < 9f && player.transform.position.y > 8f)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if ((player.transform.position.x < 107.9f && player.transform.position.x > 50f) && player.transform.position.y < 9f)
        {
            transform.eulerAngles = new Vector3(0, 0, x);
            x += 0.5f;
            if(monkey.GetComponent<monkey1>().p1 == 0)
            {
                monkey.GetComponent<monkey1>().p1 = 1;
            }
        }
        else if ((player.transform.position.x > 110f && player.transform.position.x < 147f) && player.transform.position.y < 6f)
        {
            transform.eulerAngles = new Vector3(0, 0, -180);
        }
        else if ((player.transform.position.x > 148f && player.transform.position.x < 195f) && player.transform.position.y < 9f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if ((player.transform.position.x > 195f && player.transform.position.x < 234f) && player.transform.position.y < 6f)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if ((player.transform.position.x > 196f && player.transform.position.x < 239.4f) && player.transform.position.y > 14f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if ((player.transform.position.x > 160f && player.transform.position.x < 194f) && player.transform.position.y < 33f)
        {
            transform.eulerAngles = new Vector3(0, 0, -180);
        }
        else if ((player.transform.position.x > 123f && player.transform.position.x < 160f) && player.transform.position.y > 30f)
        {
            transform.eulerAngles = new Vector3(0, 0, y);
            y += 0.5f;
        }
        else if ((player.transform.position.x > 72f && player.transform.position.x < 121f) && player.transform.position.y > 36f)
        {
            transform.eulerAngles = new Vector3(0, 0, 60);
        }
        else if ((player.transform.position.x > 42f && player.transform.position.x < 72f) && player.transform.position.y > 20f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if ((player.transform.position.x > 6f && player.transform.position.x < 34f) && player.transform.position.y < 18f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        

        else
        {
            transform.eulerAngles = new Vector3(0, 0, -90f);
        }



    }
}
