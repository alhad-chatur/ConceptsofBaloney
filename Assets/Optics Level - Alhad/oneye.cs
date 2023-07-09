using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneye : MonoBehaviour
{
    // Start is called before the first frame update
    public bool iscolliding1;
    public bool iscolliding2;
    public bool iscolliding = false;
    AudioSource asur;
    void Start()
    {
        iscolliding1 = false;
        iscolliding2 = false;
        asur = GetComponent<AudioSource>();
        asur.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (iscolliding1 || iscolliding2)
            iscolliding = true;
        else
            iscolliding = false;

        if (iscolliding == true)
        {
            if (asur.enabled == false)
           { 
                asur.enabled = true;
                asur.Play();
            } 
        }
        else
            asur.enabled = false;

    }
}
