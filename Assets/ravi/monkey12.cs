using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class monkey12 : MonoBehaviour
{

    // Start is called before the first frame update
    float iny = 0;
    float fiy = -37.0f;
    RectTransform rt;
    bool isactive = false;
    public GameObject text;
    public GameObject textbox;
    float totaltime = 0;
    public AudioClip pop;
    public GameObject p;
    AudioSource asur;
    string s11 = "Looks like we have landed on Thermodynamics arena.";
    string s12 = " Use 'Q' to absorb energy and 'E' to release energy.";

    string s21 = "Press 'F' to get inside the car.";
    string s22 = "Be aware it requires energy to bring it into motion.";

    public GameObject player;
    public GameObject bottomtxt;
    public GameObject car;
    bool isstartscreen = true;
    public int iscar = 0;
    public float delay = 0.05f;
    public string fullText;
    private bool iswriting = false;

    private string currentText = "";
    void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, iny);
       // StartCoroutine(cr());
        asur = GetComponent<AudioSource>();
        StartCoroutine(startscreen());
        car.GetComponent<carController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isstartscreen!=true)
        totaltime += Time.deltaTime;
        if(iscar == 1)
        {
            iscar = 2;
            StartCoroutine(cartext());
        }

    }
    IEnumerator startscreen()
    {
        while(isstartscreen == true)
        {
            player.GetComponent<movements>().enabled = false;

            StartCoroutine(typewriter(s11));
            while(iswriting == true)
            {
                yield return null;
            }

            StartCoroutine(typewriter(s12));
            while (iswriting == true)
            {
                yield return null;
            }
            isstartscreen = false;
            player.GetComponent<movements>().enabled = true;

        }
    }


    IEnumerator cartext()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<movements>().enabled = false;
        player.transform.Find("Aj").GetComponent<Animator>().enabled = false;
        StartCoroutine(typewriter(s21));
        while (iswriting == true)
        {
            yield return null;
        }
        StartCoroutine(typewriter(s22));
        while (iswriting == true)
        {
            yield return null;
        }
        player.GetComponent<movement>().enabled = true;
        player.transform.Find("Aj").GetComponent<Animator>().enabled = true;

    }
    IEnumerator typewriter(string input)
    {
        player.GetComponent<AudioSource>().enabled = false;
        iswriting = true;
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, fiy);
        asur.PlayOneShot(pop);
        text.SetActive(true);
        textbox.SetActive(true);
        //text.GetComponent<TMP_Text>().text = s1;
        //yield return new WaitForSeconds(5.0f);
        fullText = input;
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            text.GetComponent<TMP_Text>().text = currentText;
            yield return new WaitForSeconds(delay);
            if (i >= 10)
            {
                bottomtxt.SetActive(true);
                bottomtxt.GetComponent<TMP_Text>().text = "Press 'SpaceBar' To Skip";
                if (Input.GetKey(KeyCode.Space) == true)
                {
                    text.GetComponent<TMP_Text>().text = fullText;
                    yield return new WaitForSeconds(0.3f);
                    bottomtxt.SetActive(false);
                    break;
                }
            }
        }

        bottomtxt.SetActive(true);
        bottomtxt.GetComponent<TMP_Text>().text = "Press 'SpaceBar' To Skip";
        while (Input.GetKey(KeyCode.Space) == false)
        {
            yield return null;
        }
        bottomtxt.SetActive(false);
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, iny);
        text.SetActive(false);
        textbox.SetActive(false);
        iswriting = false;
        player.GetComponent<AudioSource>().enabled = true;
    }
}
