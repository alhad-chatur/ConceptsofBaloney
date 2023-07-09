using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light1 : MonoBehaviour
{
    LineRenderer lr;
    RaycastHit2D rh;
    public GameObject light2;
    bool rerf =false;
    GameObject newl;
    public Vector3 posi;
    Vector3 intial;
    public Vector3 dir;
    int counter;
    float r;
    GameObject n1;
    bool istouching, wastouching;
    GameObject eye1, eye2;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
        posi = Vector3.zero;
       
       GameObject l1 = GameObject.FindGameObjectWithTag("light source");
        eye1 = l1.GetComponent<light>().eye1;
        eye2 = l1.GetComponent<light>().eye2;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        rh = Physics2D.Raycast(posi, transform.up);
        lr.SetPosition(1, rh.point);
        counter = 2;
        intial = transform.position;
        lr.positionCount = 2;
        while (rh.collider.CompareTag("reflecting") == true || rh.collider.CompareTag("refracting") == true || rh.collider.CompareTag("curved refraction") == true || rh.collider.CompareTag("ref2") == true)
        {
            if (rh.collider.CompareTag("reflecting") == true)
            {
                Vector3 center = rh.transform.Find("centre").transform.position;
                Vector3 point = new Vector3(rh.point.x, rh.point.y, 0.0f);
                Vector3 normal = center - point;
                Vector3 incident = intial - point;
                float i = Vector3.Angle(incident, normal);
                if (i < 90)
                {
                    if (Vector3.Cross(incident, normal).normalized == Vector3.forward.normalized)
                        i = i;
                    else
                        i = -i;

                    Vector3 reflected = Quaternion.Euler(0, 0, i) * normal;
                    posi = point + normal * 0.1f;
                    dir = reflected;
                }
                else
                {
                    i = 180 - i;
                    if (Vector3.Cross(incident, normal).normalized == Vector3.forward.normalized)
                        i = -i;
                    else
                        i = i;

                    Vector3 reflected = Quaternion.Euler(0, 0, 2 * i) * incident;
                    posi = point - normal * 0.1f;
                    dir = reflected;
                }
                intial = posi;
                rh = Physics2D.Raycast(posi, dir.normalized);
                lr.positionCount = counter + 1;
                lr.SetPosition(counter, rh.point);


                counter++;
            }

            else if (rh.collider.CompareTag("refracting") == true)
            {
                Vector3 point = new Vector3(rh.point.x, rh.point.y, 0.0f);

                Vector3 incident = intial - point;
                Vector3 normal = new Vector3(rh.normal.x, rh.normal.y, 0.0f);
                float i = Vector3.Angle(incident, normal);
                if (Vector3.Cross(incident, normal).normalized == Vector3.forward.normalized)
                    i = i;
                else
                    i = -i;

                Vector3 refracted = Vector3.zero;
                if (Vector3.Angle(normal, rh.collider.GetComponentInParent<rm>().pos.position - point) >= 90.0f)
                {
                    float sinr = 1 / rh.collider.GetComponentInParent<rm>().ri * Mathf.Sin(Mathf.Deg2Rad * i);
                    if (sinr <= 1 && sinr > -1)
                    {
                        r = Mathf.Asin(sinr) * Mathf.Rad2Deg;
                        posi = rh.point - rh.normal * 0.07f;
                        refracted = Quaternion.Euler(0, 0, -r) * (-normal);
                    }
                    else
                    {
                        r = i * Vector3.Dot(Vector3.forward, Vector3.Cross(normal, incident).normalized) * Mathf.Sign(sinr);
                        refracted = Quaternion.Euler(0, 0, -r) * normal;
                        posi = rh.point + rh.normal * 0.07f;

                    }
                }
                else
                {
                    float sinr = rh.collider.GetComponentInParent<rm>().ri * Mathf.Sin(Mathf.Deg2Rad * i);
                    if (sinr <= 1 && sinr > -1)
                    {
                        r = Mathf.Asin(sinr) * Mathf.Rad2Deg;
                        posi = rh.point - rh.normal * 0.07f;
                        refracted = Quaternion.Euler(0, 0, -r) * (-normal);
                    }
                    else
                    {
                        r = i * Vector3.Dot(Vector3.forward, Vector3.Cross(normal, incident).normalized) * Mathf.Sign(sinr);
                        refracted = Quaternion.Euler(0, 0, -r) * normal;
                        posi = rh.point + rh.normal * 0.07f;

                    }
                }


                intial = posi;
                rh = Physics2D.Raycast(posi, refracted);
                lr.positionCount = counter + 1;
                lr.SetPosition(counter, rh.point);
                counter++;
            }
            else if (rh.collider.CompareTag("curved refraction") == true)
            {

                Vector3 point = new Vector3(rh.point.x, rh.point.y, 0.0f);
                Vector3 incident = intial - point;
                Vector3 center = rh.transform.Find("centre").transform.position;
                Vector3 normal = center - point;

                float i = Vector3.Angle(incident, normal);
                if (Vector3.Cross(incident, normal).normalized == Vector3.forward.normalized)
                    i = i;
                else
                    i = -i;

                Vector3 refracted = Vector3.zero;

                // Debug.Log(Vector3.Angle(normal, rh.collider.GetComponentInParent<rm>().pos.position - point));
                if (Vector3.Angle(normal, rh.normal) >= 90.0f)
                {
                    float sinr = (1 / rh.collider.GetComponent<rm>().ri) * Mathf.Sin(Mathf.Deg2Rad * i);
                    if (sinr <= 1 && sinr >= -1)
                    {
                        r = Mathf.Asin(sinr) * Mathf.Rad2Deg;
                        posi = rh.point - rh.normal * 0.5f;
                        refracted = Quaternion.Euler(0, 0, -r) * (-normal);

                    }
                    else
                    {
                        r = i * Vector3.Dot(Vector3.forward, Vector3.Cross(normal, incident).normalized) * Mathf.Sign(sinr);
                        refracted = Quaternion.Euler(0, 0, -r) * normal;
                        posi = rh.point + rh.normal * 0.5f;
                    }
                }
                else
                {
                    float sinr = rh.collider.GetComponentInParent<rm>().ri * Mathf.Sin(Mathf.Deg2Rad * i);
                    if (sinr <= 1 && sinr >= -1)
                    {
                        r = Mathf.Asin(sinr) * Mathf.Rad2Deg;
                        posi = rh.point - rh.normal * 0.5f;
                        refracted = Quaternion.Euler(0, 0, -r) * (-normal);

                    }
                    else               //TIR
                    {
                        r = i * Vector3.Dot(Vector3.forward, Vector3.Cross(normal, incident).normalized) * Mathf.Sign(sinr);
                        refracted = Quaternion.Euler(0, 0, -r) * normal;
                        posi = rh.point + rh.normal * 0.5f;
                    }

                }

                refracted = Quaternion.Euler(0, 0, -r) * (-normal);

                intial = posi;
                rh = Physics2D.Raycast(posi, refracted);
                lr.positionCount = counter + 1;
                lr.SetPosition(counter, rh.point);
                counter++;
            }
            else if (rh.collider.CompareTag("ref2") == true)
            {
                istouching = true;
                Vector3 center = rh.transform.Find("centre").transform.position;
                Vector3 point = new Vector3(rh.point.x, rh.point.y, 0.0f);
                Vector3 normal = center - point;
                Vector3 incident = intial - point;
                float i;

                point = new Vector3(rh.point.x, rh.point.y, 0.0f);
                incident = intial - point;
                center = rh.transform.Find("centre").transform.position;
                normal = center - point;

                i = Vector3.Angle(incident, normal);
                if (Vector3.Cross(incident, normal).normalized == Vector3.forward.normalized)
                    i = i;
                else
                    i = -i;

                Vector3 refracted = Vector3.zero;

                // Debug.Log(Vector3.Angle(normal, rh.collider.GetComponentInParent<rm>().pos.position - point));
                if (Vector3.Angle(normal, rh.normal) >= 90.0f)
                {
                    float sinr = (1 / rh.collider.GetComponent<rm>().ri) * Mathf.Sin(Mathf.Deg2Rad * i);
                    if (sinr <= 1 && sinr >= -1)
                    {
                        r = Mathf.Asin(sinr) * Mathf.Rad2Deg;
                        posi = rh.point - rh.normal * 0.5f;
                        refracted = Quaternion.Euler(0, 0, -r) * (-normal);

                    }
                    else
                    {
                        r = i * Vector3.Dot(Vector3.forward, Vector3.Cross(normal, incident).normalized) * Mathf.Sign(sinr);
                        refracted = Quaternion.Euler(0, 0, -r) * normal;
                        posi = rh.point + rh.normal * 0.5f;
                    }
                }
                else
                {
                    float sinr = rh.collider.GetComponentInParent<rm>().ri * Mathf.Sin(Mathf.Deg2Rad * i);
                    if (sinr <= 1 && sinr >= -1)
                    {
                        r = Mathf.Asin(sinr) * Mathf.Rad2Deg;
                        posi = rh.point - rh.normal * 0.5f;
                        refracted = Quaternion.Euler(0, 0, -r) * (-normal);

                    }
                    else               //TIR
                    {
                        r = i * Vector3.Dot(Vector3.forward, Vector3.Cross(normal, incident).normalized) * Mathf.Sign(sinr);
                        refracted = Quaternion.Euler(0, 0, -r) * normal;
                        posi = rh.point + rh.normal * 0.5f;
                    }

                }

                refracted = Quaternion.Euler(0, 0, -r) * (-normal);

                intial = posi;
                rh = Physics2D.Raycast(posi, refracted);
                lr.positionCount = counter + 1;
                lr.SetPosition(counter, rh.point);
                counter++;
            }
        }
        if (lr.positionCount == 2)
            wastouching = false;

        if (istouching == false)
            Destroy(n1);
        if (rh.collider.gameObject == eye1)
        {
            rh.collider.gameObject.GetComponent<oneye>().iscolliding2 = true;
        }
        else
        {
            eye1.GetComponent<oneye>().iscolliding2 = false;
        }
        if (rh.collider.gameObject == eye2)
        {
            rh.collider.gameObject.GetComponent<oneye>().iscolliding2 = true;
        }
        else
        {
            eye2.GetComponent<oneye>().iscolliding2 = false;
        }
    }
}