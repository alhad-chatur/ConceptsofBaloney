using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Distroyer : MonoBehaviour
{
    public int gameplay;


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("enemy") )
        {
            SceneManager.LoadScene(0);
        }
    }
}