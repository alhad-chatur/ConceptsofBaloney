using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movements1 : MonoBehaviour
{

    public float moveforce1 =2f;
    private float movementx1;
    private float movementy1;
   
    public float jumpforce1 = 6f;
    private Rigidbody2D rb1;

    private bool isgrounded1 = true;
 
    public Animator anim1;

   private bool ok=true;
    public Transform player11;

    private string playeranimation1="run";
    private string sliding1 = "sliding";
    private string jumping1= "jump";
    private bool m_facingright1 = true;
    private string push1 = "value";
    private string flipanimation = "flip";
    int count = 0;


    void Start()
    {
       // anim = GetComponent<Animator>();
        rb1 = GetComponent<Rigidbody2D>();
        
        
        
    }
    void Update()

    {

        if (Input.GetKeyDown(KeyCode.G) && player11.transform.position.y <0) 
        {
            rb1.gravityScale = -1;
            transform.Rotate(0f, 0f,180f);
            rb1.velocity = Vector2.up * 6f;
            count += 1;
            anim1.SetBool(flipanimation, true);

        }
         if(rb1.gravityScale == -1)
        {
            movementx1 = -Input.GetAxisRaw("Horizontal");
            //Debug.Log(movementx1);
            if (Input.GetButtonDown("Jump") && isgrounded1)
            {
                isgrounded1 = false;
                anim1.SetBool(jumping1, true);
                //rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                rb1.velocity = Vector2.down * jumpforce1;
            }

          

        }
         if(Input.GetKeyDown(KeyCode.G) && rb1.gravityScale == -1 && player11.transform.position.y>2 && isgrounded1==true)
        {
            rb1.gravityScale = 1;
            transform.Rotate(0f, 0f, 180f);
            rb1.velocity = Vector2.down * 6f;
            anim1.SetBool(flipanimation, true);
            
        }



        fliping1();
        
        playermovement1();
        palyeraniamtion1();
        slidingkar1();
        playerjump1();

        


    }

    void playermovement1()
    {
        
       
        {
            movementx1 = Input.GetAxisRaw("Horizontal");
        }
       // Debug.Log(movementx1);
        Vector3 movement = new Vector3(movementx1, 0f, 0f);

        transform.position += movement * Time.deltaTime * moveforce1;


    }
    void palyeraniamtion1()
    {
       
        if (movementx1 > 0)
        {
            
            anim1.SetBool(playeranimation1, true);
        }
        else if (movementx1 < 0)
        {
            anim1.SetBool(playeranimation1, true);
        }
        else
        {
            anim1.SetBool(playeranimation1, false);   
        }

    
    }

    void slidingkar1()
    {
        if (Input.GetKey(KeyCode.S) && m_facingright1 == true)
        {
            //Debug.Log("ravi");

            movementx1 = movementx1 + 25;
            anim1.SetBool(sliding1, true);
            // Debug.Log("hi"); 



        }
        else if (Input.GetKey(KeyCode.S) && m_facingright1 == false)
        {
            anim1.SetBool(sliding1, true);
            
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            anim1.SetBool(sliding1, true);
            transform.Rotate(0f, -180f, 0f);
        }
        else
        {
            anim1.SetBool(sliding1, false);
        }
    }

    void playerjump1()
    {


            if (Input.GetButtonDown("Jump") && isgrounded1)
            {
                isgrounded1 = false;
                anim1.SetBool(jumping1, true);
                //rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
                rb1.velocity = Vector2.up * jumpforce1;
            }
        if (isgrounded1 == false)
        {
            anim1.SetBool(jumping1, true);
        }
        }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("ground"))
        {

            {
                isgrounded1 = true;
               anim1.SetBool(jumping1, false);
                anim1.SetBool(flipanimation, false);
               
            }
        }
    
       
      

    }
   
    void playerflip1()
    {
        {
            // 
            m_facingright1 = !m_facingright1;
            transform.Rotate(0f, -180f, 0f);
           
           
        }
    }
  
    void fliping1()
    {
        if (movementx1 < 0 && m_facingright1)
        {
            playerflip1();
        }
        else if (movementx1 > 0 && !m_facingright1)
        {
            playerflip1();
        }
    }
    
}
