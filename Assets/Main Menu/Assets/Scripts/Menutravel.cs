using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menutravel : MonoBehaviour
{
    public GameObject levelpanel;
    public GameObject menupanel;
    public GameObject creditspanel;
    public GameObject optionplane;
    public GameObject exitplane;
    bool op = true;
    bool ex = true;
    public void LoadLevel()
    {
        levelpanel.SetActive(true);
        menupanel.SetActive(false);
        creditspanel.SetActive(false);
        optionplane.SetActive(false);
        exitplane.SetActive(false);
    }
    public void Loadcredits()
    {
        levelpanel.SetActive(false) ;
        menupanel.SetActive(false);
        creditspanel.SetActive(true);
        optionplane.SetActive(false);
        exitplane.SetActive(false);
    }
    public void Loadoption()
    {
        levelpanel.SetActive(false);
        menupanel.SetActive(true);
        creditspanel.SetActive(false);
        if (op)
        {
            optionplane.SetActive(true);
            op = false;
        }
        else
        {
            optionplane.SetActive(false);
            op = true;
        }
        exitplane.SetActive(false);
    }
    public void Exit()
    {
        levelpanel.SetActive(false);
        menupanel.SetActive(true);
        creditspanel.SetActive(false);
        optionplane.SetActive(false) ;
        if (ex)
        {
            exitplane.SetActive(true);
            ex = false;
        }
        else
        {
            exitplane.SetActive(false);
            ex = true;
            
        }
    }
    public void Back()
    {
        levelpanel.SetActive(false);
        menupanel.SetActive(true);
        creditspanel.SetActive(false);
        optionplane.SetActive(false);
        exitplane.SetActive(false);
    }
    public void Exitgame()
    {
        Application.Quit();
    }
}
