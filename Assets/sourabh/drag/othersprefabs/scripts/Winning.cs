using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    
    int a = 0;
    int b = 0;
    public GameObject winner;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            if ((transform.position.x >= 48.8f && transform.position.x <= 54f && transform.position.y > 36))
            {
                a = 1;
                
            }
            else if ((transform.position.x >= 188f && transform.position.x <= 193f && transform.position.y > -1.5f))
            {
                b = 1;
                
            }

            else if ((transform.position.x > 111f && transform.position.y < 2f))
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
        if (a+b > 1)
        {

            winner.SetActive(true);
        }
        
    }
}
