using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class fire : MonoBehaviour
{
    public ParticleSystem ps;
    public ParticleSystem ps1;
    public float range = 1f;
    public Transform player;
    public Transform fire1;
    public float erate = 5.0f;
    public float erate1 = 5.0f;
    
    public float rp;
    public float rp1;
    public AudioSource asur;
    public AudioClip firesounds;
    movements gg;
    // Start is called before the first frame update
    void Start()
    {
        //ps = GetComponent<ParticleSystem>();
        asur = GetComponent<AudioSource>();
        gg = FindObjectOfType<movements>();
       
    }

    // Update is called once per frame
    void Update()
    { //Debug.Log(Vector2.Distance(player.position, fire1.position));

        rp = Vector2.Distance(player.position, fire1.position);
        rp1 = player.position.x - fire1.position.x;
        if( rp1<0 && gg.movementx>0)
        {
            asur.clip = firesounds;
            asur.volume += rp / 1800;
        }
        else if(rp1<0 && gg.movementx<0)
        {
            asur.clip = firesounds;
            asur.volume -= rp / 1800;
        }
        else if(rp1 > 0 && gg.movementx > 0)
        {
            asur.clip = firesounds;
            asur.volume -= rp / 1800;
        }
        else if(rp1 < 0 && gg.movementx < 0)
        {
            asur.clip = firesounds;
            asur.volume += rp / 1800;
        }
        if (erate1 < 0)
        {
            asur.clip = firesounds;
            asur.volume = 0;
        }
        if (rp <= range)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                //Debug.Log("ravi");
                //Debug.Log(erate);
                var em = ps.emission;
                var em1 = ps1.emission;
                em.rateOverTime = erate;
                asur.clip = firesounds;
                asur.volume -= erate/1000;


                em1.rateOverTime = erate1;
                erate = erate - 0.02f;
                erate1 = erate1 - 0.02f;

            }

        }








    }
    
}
