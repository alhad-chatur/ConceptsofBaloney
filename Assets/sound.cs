using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioSource asur;
    public AudioClip bouncy;
    movements f1;
    // Start is called before the first frame update
    void Start()
    {
        f1 = FindObjectOfType<movements>();
    }

    // Update is called once per frame
    void Update()
    {
        if(f1.bouncyhai == true)
        {
            asur.clip = bouncy;
            asur.Play();
        }
    }
}
