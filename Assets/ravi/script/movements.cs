using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class movements : MonoBehaviour
{

  /*  public CharacterController cc;
    public float h = 3f;
    public float move_speed = 5f;
    public float g = -9.81f;
    public Vector3 move;*/
    public float moveforce =2f;
    public float movementx;
    public ParticleSystem dool;
    private float movementy;
    public float size;
    public float jumpforce = 9f;
    private Rigidbody2D rb;
    public Transform player;
    private bool isgrounded = true;
    public fire a11;
    public Transform wall2;
    // Vector3 vel;
    public Animator anim;
    public float size1;
    public float size2;
    public bool ok=true;
    private float move_x;
   // private int xc = 0;
    private string playeranimation="run";
    private string sliding = "sliding";
    private string jumping = "jump";
    private bool m_facingright = true;
    private string push = "value";
    public Transform wall;
    wall wallref;
    public float xp;
    public float walldistance;
    public carController car111;
    public GameObject players;
    public Transform car112;
    public float cardistance;
    private float size11;
    public Camera m_OrthographicCamera; 

    GameObject box;
    public GameObject wall456;

    public GameObject pillarpos;
    public bool hasmoved = false;
    carController CAR_controls;
    public AudioSource asur;
    public bool bouncyhai = false;
    public AudioClip carstartiingsound;
    public GameObject monkey;
    void Start()
    {
       // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        a11= FindObjectOfType<fire>();
        wallref = FindObjectOfType<wall>();
        car111 = FindObjectOfType<carController>(); 
        car111.enabled = false;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        CAR_controls = FindObjectOfType<carController> ();


    }
    void Update()

    {
      //  Debug.Log(Vector3.Distance(new Vector3(wall.transform.position.x, wall.transform.position.y, 0.0f), transform.position));
            //if((wall.position.x - player.position.x) < 0.5)
        if(Vector3.Distance(new Vector3(wall456.transform.position.x, wall456.transform.position.y,0.0f), transform.position)<4.0)        
        {
            if (Input.GetKey(KeyCode.F))
            {
                //Debug.Log("yesss");
                asur.clip = carstartiingsound;
                movementx = Input.GetAxisRaw("Horizontal");
                //  movementy = Input.GetAxisRaw("Vertical");
                Vector3 movement = new Vector3(movementx, 0f, 0f);

                wall456.transform.position += movement * Time.deltaTime * moveforce;
                if(player.position.x > 16f)
                {
                    wall456.transform.position += movement * Time.deltaTime * moveforce*3;
                }

            }


        }
        //if((wall.position.x - player.position.x) < 0.5)
        if (Vector3.Distance(new Vector3(wall.transform.position.x, wall.transform.position.y, 0.0f), transform.position) < 5.0)
        {
            if (Input.GetKey(KeyCode.G))
            {
                //Debug.Log("yesss");
                movementx = Input.GetAxisRaw("Horizontal");
                //  movementy = Input.GetAxisRaw("Vertical");
                Vector3 movement = new Vector3(movementx, 0f, 0f);

                wall.transform.position += movement * Time.deltaTime * moveforce;

            }


        }


     

        if (ok == false)
        {
            anim.SetBool(push, true);
        }
        else
        {
            anim.SetBool(push, false);
        }
       
  
        walldistance = wall2.position.x - wall.position.x;
        cardistance = car112.position.x - player.position.x;
    
        if(cardistance<4)
        {
            if (monkey.GetComponent<monkey12>().iscar == 0)
                monkey.GetComponent<monkey12>().iscar = 1;
        }

        if (Input.GetKey(KeyCode.F) && (cardistance < 4))
        {
            
            car111.enabled = true;
            players.SetActive(false);
         

        }
        if (cardistance < 4 && player.localScale.x > 0.35f && car112.localScale.x<5f )
        {
            if (Input.GetKey(KeyCode.E))
            {
                Vector3 scale = new Vector3(player.localScale.x - size1, player.localScale.y - size1, player.localScale.z - size1);
                player.localScale = scale;
                //size2 = size2 + size1/2;
                wallref.decrase();

                Vector3 scale2 = new Vector3(car112.localScale.x + size1, car112.localScale.y + size1, car112.localScale.z + size1);
                car112.localScale = scale2;

                size1 = size1 + Time.deltaTime * 0.001f;
                CAR_controls.speed += 0.5f;
                // jumpforce -= Time.deltaTime;
            }
          
        }
        if (player.localScale.x < 0.3f)
        {
            float y = player.localScale.x;
            y = 0.31f;
        }
        if(size2> 0.0006f)
        {
            size2 = 0;
        }
      
        if( ok == false&&size2 <= 0.0006f && player.localScale.x > 0.3f&& hasmoved == false)
        {
            float scalefactor = transform.localScale.x - (wall456.transform.position.x - pillarpos.transform.position.x)*0.1f;


            transform.localScale =  new Vector3(scalefactor,scalefactor,scalefactor);
            pillarpos.transform.position = wall456.transform.position;
        }
        else
            pillarpos.transform.position = wall456.transform.position;

        if (a11.rp < a11.range && a11.erate>0 && player.localScale.x < 1.6f && Input.GetKey(KeyCode.Q))
        {

          //  Debug.Log("ravi shirsat");
            Vector3 scale= new Vector3(player.localScale.x + size1 ,player.localScale.y + size1 , player.localScale.z + size1);
            player.localScale = scale;
            size1 = size1 + Time.deltaTime*0.001f;
           

        }

        if (player.localScale.x >0.46f)
        {
            wallref.increase();
        }
        if((wall.position.x - player.transform.position.x) <= 3 && hasmoved == false)
        {
            wall.GetComponent<Rigidbody2D>().AddForce(wall.right*250);
            hasmoved = true;
        }
        fliping();
        
        playermovement();
        palyeraniamtion();
        slidingkar();
        playerjump();

      
        


    }

    void playermovement()
    {
        movementx = Input.GetAxisRaw("Horizontal");
        //  movementy = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(movementx, 0f, 0f);

        transform.position += movement * Time.deltaTime * moveforce;
        

    }
    void palyeraniamtion()
    {
       
        if (movementx > 0)
        {
            
            anim.SetBool(playeranimation, true);
        }
        else if (movementx < 0)
        {
            anim.SetBool(playeranimation, true);
        }
        else
        {
            anim.SetBool(playeranimation, false);   
        }

    
    }

    void slidingkar()
    {
        if (Input.GetKey(KeyCode.S) && m_facingright == true)
        {
            //Debug.Log("ravi");

            movementx = movementx + 25;
            anim.SetBool(sliding, true);
            // Debug.Log("hi"); 



        }
        else if (Input.GetKey(KeyCode.S) && m_facingright == false)
        {
            anim.SetBool(sliding, true);
            
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool(sliding, true);
            transform.Rotate(0f, -180f, 0f);
        }
        else
        {
            anim.SetBool(sliding, false);
        }
    }

    void playerjump()
    {

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            isgrounded = false;
            anim.SetBool(jumping, true);
            //rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            rb.velocity = Vector2.up * jumpforce;
        }
        if (isgrounded == false)
        {
            anim.SetBool(jumping, true);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("car") || collision.gameObject.CompareTag("key") || collision.gameObject.CompareTag("bouncy"))
        {

            {
                isgrounded = true;
               anim.SetBool(jumping, false);
           

            }
        }
        if (collision.gameObject.CompareTag("bouncy"))
        {
            bouncyhai = true;
        }
        else
        {
            bouncyhai=false;
        }
      if (collision.gameObject.CompareTag("wall"))
        {
           
            ok = false;
            
        }
      if(collision.gameObject.CompareTag("door"))
        {
            SceneManager.LoadScene(1);
        }


       
      

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

       
            if (collision.gameObject.CompareTag("wall"))
            {
                ok = true;
            }
       
        
    }
    void playerflip()
    {
        {
            // 
            m_facingright = !m_facingright;
            transform.Rotate(0f, -180f, 0f);
            if (isgrounded == true) { 
            doolnikal();
        }


        }
    }
    void mastfunction()
    {
        xp = player.position.x - wall.position.x;
        //Debug.Log(xp);
    
        if(xp > 0.56f && xp < 0.65)
        {
            anim.SetBool(push, false);

        }
    }
    void fliping()
    {
        if (movementx < 0 && m_facingright)
        {
            playerflip();
        }
        else if (movementx > 0 && !m_facingright)
        {
            playerflip();
        }
    }

    void doolnikal()
    {

        dool.Play();
    }

}
