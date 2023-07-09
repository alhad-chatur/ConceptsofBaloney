using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadpuzzle : MonoBehaviour
{
    public void Loadp1()
    {
        SceneManager.LoadScene(2);
    }
    public void Loadp2()
    {
        SceneManager.LoadScene(3);
    }
    public void Loadp3()
    {
        SceneManager.LoadScene(4);
    }
}
