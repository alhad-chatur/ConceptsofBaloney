using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {
	public Rigidbody2D car;
	public Rigidbody2D backFire;
	public Rigidbody2D frontFire;
	public float speed = 20;
	private float movement;
	public float cartorque=10;
    public float carRotationSpeed;
	public GameObject player234;
	public carController car222;
	public AudioSource asur;
	public AudioClip carruningsound;
	//public AudioClip startingsound;
	bool issound = false;


    void Update()
	{
		issound = false;
		if (Input.GetAxis("Horizontal")!=0)
		{
			movement = Input.GetAxis("Horizontal");

            backFire.AddTorque(-movement * speed * Time.fixedDeltaTime);
			frontFire.AddTorque(-movement * speed * Time.fixedDeltaTime);
			car.AddTorque(-movement * cartorque * Time.fixedDeltaTime);
			if(asur.clip != carruningsound)
		 	 asur.clip = carruningsound;
			issound = true;
		}
		else
		{

		}
        if (Input.GetAxisRaw("Vertical")!= 0)
        {
            asur.clip = carruningsound;
            GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed * Input.GetAxisRaw("Vertical") * -1);

        }
		if (Input.GetButtonDown("Jump"))
		{
			player234.SetActive(true);
			player234.transform.position = new Vector3 (car.transform.position.x, car.transform.position.y,-3.0f);
	
			car222.enabled = false;
		}
		if (issound == true)
		{
			asur.enabled = true;
			asur.Play();
		}
		else
			asur.enabled = false;
    }
	private void Fixedupdate()
	{
		
	}

}
