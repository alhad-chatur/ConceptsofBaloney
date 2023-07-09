using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject eye1, eye2; 

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (eye1.GetComponent<oneye>().iscolliding == true && eye2.GetComponent<oneye>().iscolliding == true)
        {
            Debug.Log("hogaya");
            SceneManager.LoadScene(1);
        }


    }
}
