using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerr : MonoBehaviour
{
    public AudioSource audio;
    public Animator anim;
    public Transform target;
    public float speed = 80f;
    private Rigidbody rb;
    public LayerMask layermask;
    public bool grounded;
    public bool grounded1;
    public float st = 0.05f;
    public int forceConst = 50;
    private bool canJump;
    //public GameObject player;


    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()   
    {
        /*if (rb.velocity.y < 0)
        {
            anim.SetBool("fall", true);
        }
        else if(rb.velocity.y>=0)
        {
            anim.SetBool("fall", false);
        }*/

            
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            canJump = true;
            anim.SetBool("jump", true);
            audio.Play();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "gd" || collision.transform.tag == "anti")
        {
            grounded = true;
            anim.SetBool("jump", false);
            

        }
    }
    private void FixedUpdate()
    {
       
        if (canJump)
        {
            canJump = false;
            rb.AddForce(0, forceConst, 0, ForceMode.Impulse);
        }
    }

    

    private void Move()
    {
        float hor = 0;
        float ver = Input.GetAxis("Vertical");

        
        

        if (ver < 0 && this.transform.position.y < 7f)
        {
            ver = -ver;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(ver > 0 && this.transform.position.y < 7f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (this.transform.position.y > 7f && ver>0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(this.transform.position.y > 7f && ver < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            ver = -ver;
        }
    
        if (ver != 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
        

        Vector3 movement = this.transform.forward * hor * speed + this.transform.right * ver * speed;
        movement.Normalize();

        this.transform.position += movement * st;
        target.position += movement * st;
    }

    

}
