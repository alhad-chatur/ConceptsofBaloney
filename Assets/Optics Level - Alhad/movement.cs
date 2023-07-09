using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    Rigidbody2D rb;
    Vector2 vel;
    Vector3 vel2;
    public float speed =2;
    float diff;
    bool inrangelight = false;
    public GameObject lightsource;
    bool rotating = false;
    public float rotatingspeed = 1.0f;
    public Transform[] mirrors;
    public Transform[] slabs;
    private Transform rotatingGameobject;
    public Sprite openeye, closedeye;
    public GameObject waterslab;
    public GameObject watertext;
    bool haswaterjug =false;
    public GameObject waterjug;
    public GameObject bowl;
    public bool iswaterfilled = false;
    public GameObject waterdroptext;
    public GameObject monkey;
    AudioSource asur;
    public AudioClip rotatingmirrorssound;
    bool shouldplayaudio = false;
    public AudioClip togglesound;
    public AudioSource ienumsound;
    public AudioClip watersound;
    public AudioClip walkingsound;
  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim.SetInteger("action", 0);
        StartCoroutine(toggleobject());
        StartCoroutine(water());
        asur = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shouldplayaudio = false;
        
        if (iswaterfilled == false)
        {
            if (Vector3.Distance(transform.position, bowl.transform.position) <= 1.0f && haswaterjug == true)
            {
                waterdroptext.SetActive(true);
                waterdroptext.GetComponent<TMP_Text>().text = "Press 'K' to Pour The Water";

                if (Input.GetKey(KeyCode.K) == true)
                {
                    iswaterfilled = true;
                    bowl.tag = "ref2";
                    bowl.transform.Find("water").gameObject.SetActive(true);
                    haswaterjug = false;
                    waterjug.SetActive(false);
                    ienumsound.PlayOneShot(watersound);

                }

            }
            else
                waterdroptext.SetActive(false);

        }
        else
            waterdroptext.SetActive(false);

        lightrotate();
        rotatingmirrors();
        if (rotating == false)
            moving();
        else
            rotatingobject();

        if (haswaterjug == true)
            waterjug.SetActive(true);
        else
            waterjug.SetActive(false);
       
        animationseting();
        if (shouldplayaudio == true)
            asur.enabled = true;
        else
            asur.enabled = false;
    }

    void animationseting()
    {
        if (rotating == false)
        {
            if (vel != new Vector2(0, 0))
            {
                if (anim.GetInteger("action") != 1)
                    anim.SetInteger("action", 1);
            }
            else if (anim.GetInteger("action") != 0)
                anim.SetInteger("action", 0);
        }
        else
            anim.SetInteger("action", 2);
    }

    void moving()
    {
        vel.x = Input.GetAxisRaw("Horizontal");
        vel.y = Input.GetAxisRaw("Vertical");
        rb.velocity = vel.normalized * speed;
        vel2 = new Vector3(vel.x, vel.y, 0);
        diff = Vector3.Angle(transform.up, vel2);
        if (Vector3.Cross(transform.up, vel2).normalized == Vector3.forward.normalized)
            diff = diff;
        else
            diff = -diff;
        if(vel !=Vector2.zero)
        {
            if (asur.clip != walkingsound)
                asur.clip = walkingsound;
            shouldplayaudio = true;
        }

        transform.Rotate(0, 0, diff);
    }

    void lightrotate()
    {
        if (Vector3.Distance(transform.position, lightsource.transform.position) < 0.6f)
        {
            inrangelight = true;
        }
        else
            inrangelight = false;

        if (inrangelight == true && Input.GetKey(KeyCode.F) == true)
        {
            if (rotating == false)
            {
                transform.position = (lightsource.transform.position - lightsource.transform.up.normalized * 0.3f);
                diff = Vector3.Angle(transform.up, lightsource.transform.up);
                if (Vector3.Cross(transform.up, lightsource.transform.up).normalized == Vector3.forward.normalized)
                    diff = diff;
                else
                    diff = -diff;
                transform.Rotate(0, 0, diff);
            }
            rotating = true;
            rotatingGameobject = lightsource.transform;
        }
        else
            rotating = false;
    }
    
    void rotatingmirrors()
    {
        for (int i = 0; i < mirrors.Length; i++)
        {
            if (Vector3.Distance(transform.position, mirrors[i].Find("handle").transform.position) < 0.6f)
            {
                mirrors[i].Find("indicator").GetComponent<SpriteRenderer>().enabled = true;
                if(Input.GetKey(KeyCode.F) ==true)
                {
                    if(monkey.GetComponent<monkey>().isr ==0)
                    {
                        monkey.GetComponent<monkey>().isr = 1;
                    }
                    if (rotating == false)
                    {
                        transform.position = (mirrors[i].Find("handle").transform.position - mirrors[i].Find("handle").transform.up.normalized * 0.3f);
                        diff = Vector3.Angle(transform.right, mirrors[i].Find("handle").transform.right);
                        if (Vector3.Cross(transform.right, mirrors[i].Find("handle").transform.right).normalized == Vector3.forward.normalized)
                            diff = diff;
                        else
                            diff = -diff;
                        transform.Rotate(0, 0, diff);

                    }
                    if (Input.GetAxis("Horizontal") != 0.0f)
                    {
                        if (asur.clip != rotatingmirrorssound)
                            asur.clip = rotatingmirrorssound;
                        shouldplayaudio = true;
                    }
                    rotating = true;
                    rotatingGameobject = mirrors[i].transform;
                }
            }
            else
                mirrors[i].Find("indicator").GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void rotatingobject()
    {
        rb.velocity = Vector2.zero;
        float x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift) == true || Input.GetKey(KeyCode.RightShift) == true)
             rotatingspeed = 0.5f;
        else
            rotatingspeed = 0.01f;
        if(x!=0)
        {
            transform.RotateAround(rotatingGameobject.position, -transform.forward, x*rotatingspeed);
            rotatingGameobject.transform.Rotate(-transform.forward, x*rotatingspeed);
        }
    }

    IEnumerator water()
    {
        while(true)
        {
            if (Vector3.Distance(transform.position, waterslab.transform.position) <= 0.5f && iswaterfilled == false)
            {
                watertext.SetActive(true);
                if (haswaterjug == false)
                    watertext.GetComponent<TMP_Text>().text = "Press 'K' to collect the water";
                else
                    watertext.GetComponent<TMP_Text>().text = "Press 'K' to drop the water";

                if (Input.GetKey(KeyCode.K) == true)
                {
                    if (haswaterjug == true)
                    {
                        haswaterjug = false;
                        ienumsound.PlayOneShot(watersound);
                    }
                    else
                    {
                        haswaterjug = true;
                        ienumsound.PlayOneShot(watersound);
                    }
                    yield return new WaitForSeconds(0.3f);
                }
                else
                    yield return null;
            }
            else
            {
                watertext.SetActive(false);
                yield return null;
            }
        }
    }
        
    IEnumerator toggleobject()
    {
        while (true)
        {
            for (int i = 0; i < mirrors.Length; i++)
            {
                if (Vector3.Distance(transform.position, mirrors[i].transform.position) < 0.6f)
                {
                    mirrors[i].Find("visible").GetComponent<SpriteRenderer>().enabled = true;
                    if (Input.GetKey(KeyCode.T) == true)
                    {
                        ienumsound.PlayOneShot(togglesound);

                        if (mirrors[i].GetComponent<PolygonCollider2D>().enabled == true)
                        {
                            mirrors[i].GetComponent<PolygonCollider2D>().enabled = false;
                            mirrors[i].Find("blacking").GetComponent<PolygonCollider2D>().enabled = false;
                            mirrors[i].Find("visible").GetComponent<SpriteRenderer>().sprite = closedeye;
                            yield return new WaitForSeconds(0.5f);
                        }
                        else
                        {
                            mirrors[i].GetComponent<PolygonCollider2D>().enabled = true;
                            mirrors[i].Find("blacking").GetComponent<PolygonCollider2D>().enabled = true;
                            mirrors[i].Find("visible").GetComponent<SpriteRenderer>().sprite = openeye;
                            yield return new WaitForSeconds(0.5f);
                        }
                    }
                    else
                    {
                        yield return null;
                    }
                }
                else
                {
                    yield return null;
                    mirrors[i].Find("visible").GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            for (int i = 0; i < slabs.Length; i++)
            {
                if (Vector3.Distance(transform.position, slabs[i].Find("visible").transform.position) < 0.5f)
                {
                    slabs[i].Find("visible").GetComponent<SpriteRenderer>().enabled = true;
                    if (Input.GetKey(KeyCode.T) == true)
                    {
                        ienumsound.PlayOneShot(togglesound);

                        if (slabs[i].Find("top").GetComponent<BoxCollider2D>().enabled == true)
                        {
                            slabs[i].Find("top").GetComponent<BoxCollider2D>().enabled = false;
                            slabs[i].Find("bottom").GetComponent<BoxCollider2D>().enabled = false;
                            slabs[i].Find("right").GetComponent<BoxCollider2D>().enabled = false;
                            slabs[i].Find("left").GetComponent<BoxCollider2D>().enabled = false;
                            slabs[i].Find("visible").GetComponent<SpriteRenderer>().sprite = closedeye;
                            yield return new WaitForSeconds(0.5f);
                        }
                        else
                        {
                            slabs[i].Find("top").GetComponent<BoxCollider2D>().enabled = true;
                            slabs[i].Find("bottom").GetComponent<BoxCollider2D>().enabled = true;
                            slabs[i].Find("right").GetComponent<BoxCollider2D>().enabled = true;
                            slabs[i].Find("left").GetComponent<BoxCollider2D>().enabled = true;
                            slabs[i].Find("visible").GetComponent<SpriteRenderer>().sprite = openeye;
                            yield return new WaitForSeconds(0.5f);
                        }
                    }
                    else
                    {
                        yield return null;
                    }
                }
                else
                {
                    yield return null;
                    slabs[i].Find("visible").GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            
        }
    }

}
