using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menuscripts : MonoBehaviour
{
    public GameObject puzzlepanel;
    public GameObject menupanel;
    public GameObject optionpanel;
    bool op = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loadlevel()
    {
        menupanel.SetActive(false);
        puzzlepanel.SetActive(true);
        optionpanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Option()
    {
        if (op)
        {
            optionpanel.SetActive(true);
            op = false;
        }
        else
        {
            optionpanel.SetActive(false);
            op = true;
        }
        puzzlepanel.SetActive(false) ;
        
    }
    public void Back()
    {
        menupanel.SetActive(true);
        puzzlepanel.SetActive(false);
        optionpanel.SetActive(false);
    }
}
