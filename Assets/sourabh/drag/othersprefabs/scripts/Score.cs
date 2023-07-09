using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    int a = 0;
    int b = 0;
    int score=0;
    private TextMeshProUGUI textm;
    public GameObject winner;
    public Transform Player;
    private void Start()
    {
        textm = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if ((Player.position.x >= 48.8f && Player.position.x <= 54f && Player.position.y > 36))
            {
                a = 1;


            }
            else if ((Player.position.x >= 188f && Player.position.x <= 193f && Player.position.y > -1.5f))
            {
                b = 1;

            }
            score = a + b;
            textm.text = score.ToString();
        }
        if (a + b > 1)
        {

            winner.SetActive(true);
        }
    }
}
