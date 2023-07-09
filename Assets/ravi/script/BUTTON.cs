using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTON : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private string buttonanimation = "button";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("key") || collision.gameObject.CompareTag("wall"))
        {
            anim.SetBool(buttonanimation, true);
           // Debug.Log("true");
     
        }
        else
        {
           // Debug.Log("false");
            anim.SetBool(buttonanimation, false);
        }

    }
    

}
