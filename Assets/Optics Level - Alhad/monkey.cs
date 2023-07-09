using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class monkey : MonoBehaviour
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
    string hint1 = "HeHeHe.... too slow paced you are. Can't even solve a little puzzle.";
    string hint21 = " Wait a sec....";
    string hint22 = "I have been here. That bowl used to have water inside of it. Professor must have left the water somewhere else.";
    string s11 = "Welcome to the Optical Arena!!";
    string s12 = "The Professor was Always Obsessed with how Mirrors can be used to Manipulate the Light.";
    string s13 = "It seems that the Ray might be the Key to clear this Level.Let me think...";
    string s14 = "I got it. We have to Rotate the Ray in such a Manner that after certain Reflections and Refractions it reaches both the eyes.";

    string s21 = "Hold the Point P using 'F' and Try to Rotate it.";
    string s22 = "There are a Lot of Objects here. We can Enable or Disable them using 'T'. (Eye Sign)";

    string s31 = "We can also Rotate the Mirrors by Holding them using 'F'.(Rotation Sign)";

    string s41 = "It seems that Rotating Speed is a bit low, try using 'Shift' key as well.";
    public GameObject player;
    public GameObject bottomtxt;
    bool isstartscreen = true;
    bool isp = true;
    bool ist = true;
    public int isr = 0;
    bool taunt = true;
    bool hint = true;

    public GameObject bg;
    public Sprite bg1;
    public Sprite bg2;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(isstartscreen!=true)
        totaltime += Time.deltaTime;
        if(Vector2.Distance(player.transform.position,p.transform.position)<=1.0f && isp ==true)
        {
            StartCoroutine(pointp());
            isp = false;
        }
        if (Input.GetKey(KeyCode.T) == true && ist == true)
        {
            StartCoroutine(t());
            ist = false;
        }
        if(isr == 1)
        {
            StartCoroutine(r());
            isr = 2;
        }
        if(totaltime>=300 && taunt ==true)
        {
            StartCoroutine(tauntl());
            taunt = false;
        }
        if(hint==true && totaltime >=400.0f && player.GetComponent<movement>().iswaterfilled == false)
        {
            StartCoroutine(hintl());
            hint = false;
        }
    }

    IEnumerator tauntl()
    {     
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.GetComponent<movement>().enabled = false;
                player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = false;
                StartCoroutine(typewriter(hint1));
                while (iswriting == true)
                {
                    yield return null;
                }
                player.GetComponent<movement>().enabled = true;
                player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = true;
    }
    IEnumerator startscreen()
    {
        while(isstartscreen == true)
        {
            player.GetComponent<movement>().enabled = false;
            bg.GetComponent<SpriteRenderer>().sprite = bg1;

            StartCoroutine(typewriter(s11));
            while(iswriting == true)
            {
                yield return null;
            }
            bg.GetComponent<SpriteRenderer>().sprite = bg2;


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
            StartCoroutine(typewriter(s14));
            while (iswriting == true)
            {
                yield return null;
            }
            isstartscreen = false;
            player.GetComponent<movement>().enabled = true;

        }
    }
    IEnumerator pointp()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<movement>().enabled = false;
        player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = false;
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
         player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = true;
    }

    IEnumerator t()
    {
        yield return new WaitForSeconds(1.0f);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<movement>().enabled = false;
        player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = false;
        StartCoroutine(typewriter(s31));
        while (iswriting == true)
        {
            yield return null;
        }
        player.GetComponent<movement>().enabled = true;
        player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = true;

    }

    IEnumerator r()
    {
        yield return new WaitForSeconds(1.0f);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<movement>().enabled = false;
        player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = false;
        StartCoroutine(typewriter(s41));
        while (iswriting == true)
        {
            yield return null;
        }
        player.GetComponent<movement>().enabled = true;
        player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = true;

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
    IEnumerator hintl()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<movement>().enabled = false;
        player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = false;
        StartCoroutine(typewriter(hint21));
        while (iswriting == true)
        {
            yield return null;
        }
        StartCoroutine(typewriter(hint22));
        while (iswriting == true)
        {
            yield return null;
        }
        player.GetComponent<movement>().enabled = true;
        player.transform.Find("Aj (1)").GetComponent<Animator>().enabled = true;
    }

}
