using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wall : MonoBehaviour
{
    private Rigidbody2D rb;
    public movements sd;
    public Transform wall1;
    public Transform player;
    movements anim1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sd = FindObjectOfType<movements>();
        anim1 = FindObjectOfType<movements>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(sd.size1);
        if (wall1.position.x > 5)
        {
           gameObject.tag = "ground";
            anim1.anim.SetBool("value", false);
            sd.ok = true;
            rb.constraints = RigidbodyConstraints2D.None;


        }
        decrase();
        
        

    }
     public void decrase()
    {
        if (player.localScale.x<0.46f   )
        {
           // Debug.Log("raviiiiiiiiiiii");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
         //   rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }
    public void increase()
    {
        
            //Debug.Log("raviiii");
            rb.constraints = RigidbodyConstraints2D.None;

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;




       
    }
}
