using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public static bool Gamepause = true;

    public GameObject PauseUi;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gamepause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseUi.SetActive(false);
        Gamepause = false;
    }
    void Pause()
    {
        Time.timeScale = 0f;
        PauseUi.SetActive(true);
        Gamepause = true;
    }

    public void Loadmenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
