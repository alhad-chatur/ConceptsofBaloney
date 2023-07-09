using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class keylock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject obj1;
    public fire emition;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    public AudioSource asur;
    public AudioClip fallingrock;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    // public Collider2D col;
    private string lakshyasaala = "LAKSHYA";
    private int  isdistroyed=0;
  //  public Animation keylock1;
    [SerializeField] private Animator _animator;

    void Start()
    {
        emition = FindObjectOfType<fire>();
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        //keylock1 = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("key")) {
            Destroy(obj);
            float erate = 5.0f;
            float erate1 = 5.0f;
            emition.erate = 5.0f;
            isdistroyed +=1;
                emition.erate1 = 5.0f;
            if (isdistroyed ==1)
            {
                asur.clip = fallingrock;
                asur.Play();
            }
            
            arrow1.SetActive(true);
            arrow2.SetActive(true);
            arrow3.SetActive(true);
              
          //   Debug.Log("ravi shirsat");
            //Debug.Log(erate);
            var em = ps.emission;
            var em1 = ps1.emission;
            em.rateOverTime = erate;



            em1.rateOverTime = erate1;

            _animator.SetBool(lakshyasaala, true);
            Destroy(obj1);
            //  keylock1.Play();


        }
        else
        {
            _animator.SetBool(lakshyasaala, false);
        }     
    }
}
