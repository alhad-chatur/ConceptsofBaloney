using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class monkey1 : MonoBehaviour
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
    AudioSource asur;

    string s11 = "Here comes the gravitational arena!!";
    string s12 = "Ever wondered what would happen if earth's gravity were changing place to place.";
    string s13 = "The professor has designed this planet with variable mass system and contains lots of suprises.";
    string hint21 = "Be ready to experience the rotation of this planet, hold tight...";
    string hint31 = " To jump into next level,we have to identify points where physical behaviour of this planet is similar to our earth's. ";
    string hint32 = "Press 'P' if you are at such locations.";
    public GameObject player;
    public GameObject bottomtxt;
    bool isstartscreen = true;

    public float delay = 0.05f;
    public string fullText;
    private bool iswriting = false;

    public int p1, p2;

    private string currentText = "";
    void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, iny);
       // StartCoroutine(cr());
        asur = GetComponent<AudioSource>();
        StartCoroutine(startscreen());
        p1 = 0;
        p2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(isstartscreen!=true)
        totaltime += Time.deltaTime;
        if(p1==1)
        {
            StartCoroutine(hints1());
            p1 = 2;
        }
        if (p2 == 1 && totaltime>=3)
        {
            StartCoroutine(hints2());
            p2 = 2;
        }
    }

    IEnumerator startscreen()
    {
        while(isstartscreen == true)
        {
            player.GetComponent<Playerr>().enabled = false;

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
            StartCoroutine(typewriter(s13));
            while (iswriting == true)
            {
                yield return null;
            }
            isstartscreen = false;
            player.GetComponent<Playerr>().enabled = true;

        }
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

    IEnumerator hints1()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Playerr>().enabled = false;
        player.transform.Find("Aj").GetComponent<Animator>().enabled = false;
        StartCoroutine(typewriter(hint21));
        while (iswriting == true)
        {
            yield return null;
        }

        player.GetComponent<Playerr>().enabled = true;
        player.transform.Find("Aj").GetComponent<Animator>().enabled = true;
    }

    IEnumerator hints2()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Playerr>().enabled = false;
        player.transform.Find("Aj").GetComponent<Animator>().enabled = false;
        StartCoroutine(typewriter(hint31));
        while (iswriting == true)
        {
            yield return null;
        }
        StartCoroutine(typewriter(hint32));
        while (iswriting == true)
        {
            yield return null;
        }
        player.GetComponent<Playerr>().enabled = true;
        player.transform.Find("Aj").GetComponent<Animator>().enabled = true;
    }
}
