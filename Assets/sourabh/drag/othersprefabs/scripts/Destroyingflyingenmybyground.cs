using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyingflyingenmybyground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fly"))
        {

            Destroy(collision.gameObject);
            
        }
        
    }
    

}
