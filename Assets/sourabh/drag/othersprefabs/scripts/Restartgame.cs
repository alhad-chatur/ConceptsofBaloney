using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartgame : MonoBehaviour
{
    public Transform particle;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "khatam")
        {
            if ((transform.position.x > 111f && transform.position.y < 2f))
            {
                transform.position = new Vector3(113.9f, 0.64f, -0.11f);
                
            }
            else if ((transform.position.x < 192f && transform.position.y > 32f))
            {
                transform.position = new Vector3(191.94f, 34.49f, -0.11f);
            }
            else if ((transform.position.x > 50f && transform.position.y > 33f))
            {
                transform.position = new Vector3(50.9f, 37.78f, -0.11f);
            }
            else
            {
                transform.position = new Vector3(3.57f, 4.178f, -0.11f);
            }
        }
    }
}
